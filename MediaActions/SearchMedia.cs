using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes.MediaActions
{
    public class SearchMedia : AllMedia 
    {
        
        public override void SearchAll()
        {
            // instantiate our context
            Context context = new Context();

            // ask the user for the search string
            Console.WriteLine("What title would you like to search?");
            var searchString = Console.ReadLine();

            // this is where the 'orchestrator' could come in to combine all these into a single method call
            List<MovieType> movies = context.Movies.Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            List<ShowType> shows = context.Shows.Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            List<VideoType> videos = context.Videos.Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

            // add all the results to a single list of the base type
            List<MediaType> results = new List<MediaType>();
            results.AddRange(movies);
            results.AddRange(shows);
            results.AddRange(videos);

            // loop over the combined results and output them
            foreach (var mediaType in results)
            {
                // this is using something called 'reflection'
                // will put you "movie/show/video" depending on what title was given
                Console.WriteLine($"Your {mediaType.GetType().Name}: {mediaType.Title}");
            }
            // ** Why does the search not display the media? Is the results list currently considered empty?
            // ** Or is it that the MovieType, ShowType and VideoType lists are not in list form
        }
    }
}


