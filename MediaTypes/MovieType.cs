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
            Console.WriteLine($"ID: {Id}, Title: {Title}, Genre(s): {Genres}");

        }
    }
}
