using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public class Rectangle
    {

        public Rectangle(float latMin, float latMax, float lonMin, float lonMax) 
        {
            LatMin = latMin;
            LatMax = latMax;

            LonMin = lonMin;
            LonMax = lonMax;

        }

        public float LatMin { get; set; }  
        public float LatMax { get; set; }  
        public float LonMin { get; set; }
        public float LonMax { get; set; }

     }
}
