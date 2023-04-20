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
            var daVehicleList = Utils.LoadVehicleList();
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

                // See if the test Vehicles are within the Range
                foreach (var TV in TestVehicles)
                { 
                    Console.WriteLine(Utils.VehicleIsInBox(TV, new MixTeleMatrix.Rectangle(LatMin, LatMax, LonMin, LonMax)));
                }

        }
    }
}