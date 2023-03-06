using Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation;
using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes
{
    public class AbstractUsage
    {
        static void Main(string[] args)
        {
            var movieType = new MovieType();
            movieType.Display();

            var showType = new ShowType();
            showType.Display();

            var videoType = new VideoType();
            videoType.Display();

        }
    }
}
