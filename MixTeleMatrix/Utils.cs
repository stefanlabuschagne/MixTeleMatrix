using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public static class Utils
    {

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

            // Calcutalethe Base Area
            var sortedLatReadinglist = daVehicleList.OrderByDescending(p => p.Latitude);

            var LatMax = sortedLatReadinglist.FirstOrDefault().Latitude;
            var LatMin = sortedLatReadinglist.LastOrDefault().Latitude;

            var sortedLongReadinglist = daVehicleList.OrderByDescending(p => p.Longitude);

            var LonMax = sortedLongReadinglist.FirstOrDefault().Longitude;
            var LonMin = sortedLongReadinglist.LastOrDefault().Longitude;

            return new MixTeleMatrix.Rectangle(LatMin, LatMax, LonMin, LonMax);

        }

        // See if the vehicle is in the box
        public static bool VehicleIsInRectangle(Vehicle vehicle1, MixTeleMatrix.Rectangle Box)
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


       public static List<Vehicle> LoadVehicleList()
        {
            var daVehicleList = new List<Vehicle>();

            using (var stream = File.Open($"C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\VehiclePositions.dat", FileMode.Open))
            {

                try
                {

                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        while (true)
                        {

                            var daVehicle = new Vehicle();

                            daVehicle.Positionid = reader.ReadInt32();
                            char c = reader.ReadChar();
                            while (c != '\0')
                            {
                                daVehicle.VehicleRegistration = daVehicle.VehicleRegistration + c;
                                c = reader.ReadChar();
                            }
                            daVehicle.Latitude = reader.ReadSingle();
                            daVehicle.Longitude = reader.ReadSingle();
                            daVehicle.RecordedTimeUTC = (ulong)reader.ReadInt64();

                            // Console.WriteLine(daVehicle.Latitude + ";" + daVehicle.Longitude + ";" + daVehicle.VehicleRegistration);

                            daVehicleList.Add(daVehicle);

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

            return daVehicleList;

        }

    }
}
