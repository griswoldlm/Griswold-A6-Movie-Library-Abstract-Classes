using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
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
            var listMovie = File.ReadAllLines($"{Environment.CurrentDirectory}/movies.json");
            foreach (var item in listMovie)
            {
                var movie = JsonConvert.DeserializeObject<MovieType>(item);
                Movies.Add(movie);
            }

            Shows = new List<ShowType>();
            var listShow = File.ReadAllLines($"{Environment.CurrentDirectory}/shows.json");
            foreach (var item in listShow)
            {
                var show = JsonConvert.DeserializeObject<ShowType>(item);
                Shows.Add(show);
            }


            Videos = new List<VideoType>();
            var listVideos = File.ReadAllLines($"{Environment.CurrentDirectory}/videos.json");
            foreach (var item in listVideos)
            {
                var video = JsonConvert.DeserializeObject<VideoType>(item);
                Videos.Add(video);
            }
        }
    }
}