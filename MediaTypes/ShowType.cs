using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation
{
    public abstract class ShowType : MediaType
    {
        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public string Display()
        {
            return $"ID: {Id}, Title: {Title}, Season: {Season}, Episode: {Episode}, Writer(s): {Writers}";

        }
    }
}
