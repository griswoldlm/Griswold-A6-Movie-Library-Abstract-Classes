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

        public override void Display()
        {
            string file = $"{Environment.CurrentDirectory}/shows.csv";
            StreamReader sr1 = new StreamReader(file);

            // Skip header
            sr1.ReadLine();

            // Read movie.csv file
            while (!sr1.EndOfStream)
            {
                var line = sr1.ReadLine();
                string[] arr = line.Split(',');
                Console.WriteLine($"ID: {arr[0]}, Title: {arr[1]}, Season: {arr[2]}, Episode: {arr[3]}, Writer(s): {arr[4]}");
            }
            //Console.WriteLine($"ID: {Id}, Title: {Title}, Season: {Season}, Episode: {Episode}, Writer(s): {Writers}"); showId,title,season,episode,writer
        }
    }
}
