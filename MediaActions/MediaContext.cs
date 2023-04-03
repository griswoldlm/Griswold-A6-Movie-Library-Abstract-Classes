using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes.MediaActions
{
    public class Context
    {
        public List<MovieType> Movies { get; set; }
        public List<ShowType> Shows { get; set; }
        public List<VideoType> Videos { get; set; }

        public Context()
        {
            Movies = new List<MovieType>();
            string file = $"{Environment.CurrentDirectory}/movies.csv";
            StreamReader sr = new StreamReader(file);

            Shows = new List<ShowType>();
            string file1 = $"{Environment.CurrentDirectory}/shows.csv";
            StreamReader sr1 = new StreamReader(file1);

            Videos = new List<VideoType>();
            string file2 = $"{Environment.CurrentDirectory}/videos.csv";
            StreamReader sr2 = new StreamReader(file2);
        }
    }
}