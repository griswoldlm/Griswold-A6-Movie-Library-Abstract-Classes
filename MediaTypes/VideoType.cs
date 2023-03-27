using Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes.MovieInformation
{
    public  class VideoType : MediaType
    {
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public override void Display()
        {
            string file = $"{Environment.CurrentDirectory}/videos.csv";
            StreamReader sr1 = new StreamReader(file);

            // Skip header
            sr1.ReadLine();

            // Read movie.csv file
            while (!sr1.EndOfStream)
            {
                var line = sr1.ReadLine();
                string[] arr = line.Split(',');
                Console.WriteLine($"ID: {arr[0]}, Title: {arr[1]}, Format: {arr[2]}, Length: {arr[3]}, Region(s): {arr[4]}");
            }

            //Console.WriteLine($"ID: {Id}, Title: {Title}, Format: {Format}, Length: {Length}, Region(s): {Regions}");

        }
    }
}
