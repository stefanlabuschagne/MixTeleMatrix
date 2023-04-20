using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public static class Utils
    {

        // See if the vehicle is in the box
        public static bool VehicleIsInBox(Vehicle vehicle1, MixTeleMatrix.Rectangle Box)
        {

            if ((vehicle1.Latitude <= Box.LatMax)
                && (vehicle1.Latitude >= Box.LatMin)
                    && (vehicle1.Longitude <= Box.LonMax)
                        && (vehicle1.Longitude >= Box.LonMin))
            { return true; }

            return false;

        }


    }
}
