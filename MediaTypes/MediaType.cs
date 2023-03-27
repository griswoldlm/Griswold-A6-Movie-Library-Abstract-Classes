using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griswold_A6_Movie_Library_Abstract_Classes.MediaTypes
{
    public abstract class MediaType
    {
        public UInt64 Id { get; set; }
        public string Title { get; set; }
        public abstract void Display();    
    }
}
       
         

