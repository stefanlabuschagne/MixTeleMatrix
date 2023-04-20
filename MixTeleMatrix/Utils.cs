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

        public static List<Vehicle> GetTestVehcles()
        {

            var TestVehicleList = new List<Vehicle>()
                 {
    
                        new Vehicle()
        {
            Positionid = 1,
                        Latitude = (float)34.544909,
                        Longitude = (float)-102.100843
                    },
                    new Vehicle()
        {
            Positionid = 2,
                        Latitude = (float)32.345544,
                        Longitude = (float)-99.123124
                    },
                    new Vehicle()
        {
            Positionid = 3,
                        Latitude = (float)33.234235,
                        Longitude = (float)-100.214124
                    },
                    new Vehicle()
        {
            Positionid = 4,
                        Latitude = (float)35.195739,
                        Longitude = (float)-95.348899
                    },
                    new Vehicle()
        {
            Positionid = 5,
                        Latitude = (float)31.895839,
                        Longitude = (float)-97.789573
                    },
                    new Vehicle()
        {
            Positionid = 6,
                        Latitude = (float)32.895839,
                        Longitude = (float)-101.789573
                    },
                    new Vehicle()
        {
            Positionid = 7,
                         Latitude = (float)34.115839,
                         Longitude = (float)-100.225732
                     },
                    new Vehicle()
        {
            Positionid = 8,
                         Latitude = (float)32.335839,
                         Longitude = (float)-99.992232
                     },
                    new Vehicle()
        {
            Positionid = 9,
                        Latitude = (float)33.535339,
                        Longitude = (float)-94.792232
                    },
                    new Vehicle()
        {
            Positionid = 10,
                        Latitude = (float)32.234235,
                        Longitude = (float)-100.222222
                    }
    };

    return TestVehicleList;
}
    }
}
