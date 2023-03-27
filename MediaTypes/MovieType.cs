using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation
{
    public abstract class MovieType : MediaType
    {
        string[] Genres { get; set; }

        public override void Display()
        {
            string file = $"{Environment.CurrentDirectory}/movies.csv";
            StreamReader sr1 = new StreamReader(file);

            // Skip header
            sr1.ReadLine();

            // Read movie.csv file
            while (!sr1.EndOfStream)
            {
                var line = sr1.ReadLine();
                string[] arr = line.Split(',');
                Console.WriteLine($"ID: {arr[0]}, Title: {arr[1]}, Genre(s): {arr[2]}");
            }
            //Console.WriteLine($"ID: {Id}, Title: {Title}, Genre(s): {Genres}");
        }
    }
}
