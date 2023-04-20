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

                List<Vehicle> TestVehicles = Utils.GetTestVehcles();

                // See if the test items are within the Range
                foreach (var TV in TestVehicles)
                { 
                    Console.WriteLine(Utils.VehicleIsInBox(TV, new MixTeleMatrix.Rectangle(LatMin, LatMax, LonMin, LonMax)));
                }

                //foreach (var V in TestVehicles)
                //    (
                //        // Console.WriteLine(QT.GetNearsestVehicle(V))
                //    )



        }
    }
}