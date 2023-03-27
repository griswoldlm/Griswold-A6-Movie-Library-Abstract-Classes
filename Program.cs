using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation;
using System.Reflection.Metadata;

namespace Griswold_A6_Movie_Library_Abstract_Classes
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {

            // path to movie data file

            string file = $"{Environment.CurrentDirectory}/movies.csv";

            // make sure file exists
            if (!File.Exists(file))
            {
                {
                    Console.WriteLine("File does not exist. \nFile has been created.");
                    //create file
                    StreamWriter sw = new StreamWriter(file, true);
                }
            }
            else
            {
                string choice;
                do
                {
                    // Choices for user to choose
                    Console.WriteLine("1. Add Movie(s)");
                    Console.WriteLine("2. Display Movies");
                    Console.WriteLine("3. Display Shows");
                    Console.WriteLine("4. Display Videos");
                    Console.WriteLine("Press Enter To Exit");

                    // Receive user input
                    choice = Console.ReadLine();

                    // Lists to be populated with new movies -- eventually turn into classes, methods, etc.
                    List<ulong> MovieIDs = new List<ulong>();
                    List<string> MovieTitles = new List<string>();
                    List<string> MovieGenres = new List<string>();

                    // Read from movies.csv
                    StreamReader sr = new StreamReader(file);

                    // Remove headers when option 2 is choosen
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        // Look for quotes that surround commas in movie titles -- use IndexOf
                        int idx = line.IndexOf('"');

                        // No quote no comma
                        if (idx == -1)
                        {
                            // Split with commma, make as arrays like ticketing program
                            string[] movieDetails = line.Split(',');

                            // Array 0 - movie id
                            MovieIDs.Add(ulong.Parse(movieDetails[0]));

                            // Array 1 - movie title
                            MovieTitles.Add(movieDetails[1]);

                            // Array 2 - movie genre(s) -- need to replace | w/ comma(s) b/c csv file
                            MovieGenres.Add(movieDetails[2].Replace("|", ", "));
                        }
                        // Contains quotes and commas -- still need to replace | w/ comma(s) b/c csv file
                        else
                        {
                            // Find movieID 
                            MovieIDs.Add(ulong.Parse(line.Substring(0, idx - 1)));

                            // Remove movieID and find first quote
                            line = line.Substring(idx + 1);

                            // Find next quote
                            idx = line.IndexOf('"');

                            // Find whole movie title
                            MovieTitles.Add(line.Substring(0, idx));

                            // Remove whole movie title and last comma
                            line = line.Substring(idx + 2);

                            // Replace all | w/ commas in genres b/c csv file
                            MovieGenres.Add(line.Replace("|", ", "));
                        }
                    }
                    // Always close!!
                    sr.Close();

                    // Ask for movie info to add movie to csv
                    if (choice == "1")
                    {
                        // Ask for movie title
                        Console.WriteLine("What is the title of the movie you would like to add?");

                        // Input title
                        string movieTitle = Console.ReadLine();

                        // Check for duplicates
                        List<string> LowerCaseMovieTitles = MovieTitles.ConvertAll(t => t.ToLower());
                        if (LowerCaseMovieTitles.Contains(movieTitle.ToLower()))
                        {
                            Console.WriteLine("A movie with this title already exists.");
                        }
                        else
                        {
                            // New movie id - use max value + 1 -- similiar to sql window function LAST_VALUE
                            ulong movieId = MovieIDs.Max() + 1;

                            // Ask for movie genre(s)
                            List<string> genres = new List<string>();

                            string genre;

                            do
                            {
                                // Ask for genre(s)
                                Console.WriteLine("What genre(s) does this movie have? Or 'quit' to complete movie genre(s)");

                                // Input genre
                                genre = Console.ReadLine();

                                // If user enters "quit" or doesn't add genre
                                if (genre != "quit" && genre.Length > 0)
                                {
                                    genres.Add(genre);
                                }

                            } while (genre != "quit");

                            // ZERO added
                            if (genres.Count == 0)
                            {
                                genres.Add("none");
                            }

                            // Display genre(s) with | as delimiter
                            string genresString = string.Join("|", genres);

                            // Put quotes around commma(s) in movie title
                            movieTitle = movieTitle.IndexOf(',') != -1 ? $"\"{movieTitle}\"" : movieTitle;

                            // Display all movie info when addition's complete
                            Console.WriteLine($"{movieId}, {movieTitle}, {genresString}");

                            // Create file from data and follow csv requirements
                            StreamWriter sw = new StreamWriter(file, true);

                            sw.WriteLine($"{movieId}, {movieTitle}, {genresString}");

                            // ALWAYS CLOSE!!!
                            sw.Close();

                            // Add movie info to list
                            MovieIDs.Add(movieId);
                            MovieTitles.Add(movieTitle);
                            MovieGenres.Add(genresString);
                        }
                    }
                    // Display Movies
                    else if (choice == "2")
                    {
                        MovieType movieType = new MovieType();
                        movieType.Display();
                    }
                    // Display Shows
                    else if (choice == "3")
                    {
                        ShowType showType = new ShowType();
                        showType.Display();
                    }
                    // Display videos
                    else if (choice == "4")
                    {
                        VideoType videoType = new VideoType();
                        videoType.Display();
                    }

                    sr.Close(); // Always close!!!
                } while (choice == "1" || choice == "2" || choice == "3" || choice == "4");
            }
        }
    } 
}