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

        public Rectangle(float LatMin, float LatMax, float LonMin, float LonMax) 
        {
            LatMin = LatMin;
            LatMax = LatMax;

            LonMin = LonMin;
            LonMax = LonMax;

        }

        public float LatMin { get; set; }  
        public float LatMax { get; set; }  
        public float LonMin { get; set; }
        public float LonMax { get; set; }

     }
}
