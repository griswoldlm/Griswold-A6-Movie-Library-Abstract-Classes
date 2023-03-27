using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation
{
    public abstract class VideoType : MediaType
    {
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public override void Display()
        {
            Console.WriteLine($"ID: {Id}, Title: {Title}, Format: {Format}, Length: {Length}, Region(s): {Regions}");

        }
    }
}
