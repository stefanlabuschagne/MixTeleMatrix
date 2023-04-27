using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public class Rectangle : IRectangle
    {

        public Rectangle(float latMin, float latMax, float lonMin, float lonMax)
        {
            LatMin = latMin;
            LatMax = latMax;

            LonMin = lonMin;
            LonMax = lonMax;
        }

        public float LatMin { get; }
        public float LatMax { get; }
        public float LonMin { get; }
        public float LonMax { get; }

    }
}
