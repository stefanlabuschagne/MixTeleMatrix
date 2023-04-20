using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Linq;

namespace MixTeleMatrix
{
    internal class Program
    {
        static void Main(string[] args)
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

                            // Add The point Tothe Quad Tree

                            Console.WriteLine(daVehicle.Latitude + ";" + daVehicle.Longitude + ";" + daVehicle.VehicleRegistration);


                            // Add The point Tothe Quad Tree
                            // Not a List Anymore

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

                // When we are here we have 2 Million Points!

                // Calcutalethe Base Area
                var sortedLatReadinglist = daVehicleList.OrderByDescending(p => p.Latitude);

                var LatMax = sortedLatReadinglist.FirstOrDefault().Latitude;
                var LatMin = sortedLatReadinglist.LastOrDefault().Latitude;

                var sortedLongReadinglist = daVehicleList.OrderByDescending(p => p.Longitude);

                var LonMax = sortedLongReadinglist.FirstOrDefault().Longitude;
                var LonMin = sortedLongReadinglist.LastOrDefault().Longitude;

                // Initalize the Quad Tree with the BaseArea
                QuadTree QT = new QuadTree(
                    new MixTeleMatrix.Rectangle(LatMin, LatMax, LonMin, LonMax)
                    );

                foreach (var v in sortedLatReadinglist)
                {
                    QT.AddVehicle(v);
                }

                 List<Vehicle> TestVehicles = new List<Vehicle>() 
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
                        Latitude = (float) 32.345544,
                        Longitude = (float) -99.123124
                    },
                    new Vehicle()
                    {
                        Positionid = 3,
                        Latitude = (float) 33.234235,
                        Longitude = (float) -100.214124
                    },
                    new Vehicle()
                    {
                        Positionid = 4,
                        Latitude = (float) 35.195739,
                        Longitude = (float) -95.348899
                    },
                    new Vehicle()
                    {
                        Positionid = 5,
                        Latitude = (float) 31.895839,
                        Longitude = (float) -97.789573
                    },

                 };


            }
        }
    }
}