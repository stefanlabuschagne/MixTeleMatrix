using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public static class Utils
    {

        public static int CalculateQuadrantIndex(Rectangle R,int GridDimensions,Vehicle V)
        {
            // Returns the QuadrantIndex Index we need to add the  
            float QuadrantWidth = (R.LonMax - R.LonMin) / GridDimensions;   // Width of a Quadrant
            float QuadrantHeight = (R.LatMax - R.LatMin) / GridDimensions;   // Height of a Quadrant

            float LatOffset = R.LatMin - V.Latitude;  // distance  from the bottom
            float LonOffset = V.Longitude - R.LonMin;   // distance from the left

            int rows = Math.Abs((int) (LatOffset / QuadrantHeight));  // # rows we span from the bottom
            int cols = (int) (LonOffset / QuadrantWidth);  // #  Cols we span 


            // Rows are built bottomLeft -up into columns

            int returnIndex = (rows) + (cols * GridDimensions);

            // Convert this to a Tabindex
            return (returnIndex);

        }

        public static double CalculateDistance(Vehicle vehicle1, Vehicle vehicle2)
        {
            // Calculate the Distance
            var horDistance = Math.Abs(vehicle1.Longitude - vehicle2.Longitude);
            var verDistance = Math.Abs(vehicle1.Latitude - vehicle2.Latitude);

            var directDistance = (Math.Sqrt(
                                            (Math.Pow(horDistance, 2)) +
                                            (Math.Pow(verDistance, 2))
                                            ));

            return (directDistance);
        }

        public static MixTeleMatrix.Rectangle CalculateAreaRectangle(List<Vehicle> daVehicleList)
        {
            // Calcutale the Base Area
            float LatMax = float.MinValue;
            float LatMin = float.MaxValue;

            float LonMax = float.MinValue;
            float LonMin = float.MaxValue;

            // Fatster than Uning LINQ
            foreach (Vehicle V in daVehicleList)
            {

                LatMax = (V.Latitude > LatMax) ? V.Latitude : LatMax;
                LatMin = (V.Latitude < LatMin) ? V.Latitude : LatMin;

                LonMax = (V.Longitude > LonMax) ? V.Longitude : LonMax;
                LonMin = (V.Longitude < LonMin) ? V.Longitude : LonMin;

            }

            return new MixTeleMatrix.Rectangle(LatMin, LatMax, LonMin, LonMax);

        }

        // See if the vehicle is in the box
        public static bool VehicleIsInArea(Vehicle vehicle1, MixTeleMatrix.Rectangle Box)
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

        return( new List<Vehicle>()
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
                });

        }

       public static List<Vehicle> LoadVehicleList(string Filename)
        {
            var ReturnVehicleList = new List<Vehicle>();
            ReturnVehicleList.Capacity = 2000010;
            StringBuilder VehicleRegistration = new StringBuilder();

            using (var stream = File.Open(Filename, FileMode.Open))
            {
                try
                {

                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        while (true)
                        {

                            var InputVehicle = new Vehicle();
                            InputVehicle.Positionid = reader.ReadInt32();
                            char c = reader.ReadChar();
                            while (c != '\0')
                            {
                                VehicleRegistration.Append(c);
                                c = reader.ReadChar();
                            }
                            InputVehicle.VehicleRegistration = VehicleRegistration.ToString();
                            VehicleRegistration.Clear();
                            InputVehicle.Latitude = reader.ReadSingle();
                            InputVehicle.Longitude = reader.ReadSingle();
                            InputVehicle.RecordedTimeUTC = (ulong)reader.ReadInt64();
                            ReturnVehicleList.Add(InputVehicle);

                        }

                    }

                }
                catch (Exception exception)
                {
                }
                finally
                {
                }

            }

            return ReturnVehicleList;

        }

    }
}
