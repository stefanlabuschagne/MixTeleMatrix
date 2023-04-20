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


            // Initalize the Quad Tree with the BaseArea
            // Calculate Quadrants
            // Load the vehicles into the Quadrants
            QuadTree QT = new QuadTree(daVehicleList);

            List<Vehicle> TestVehicles = Utils.GetTestVehcles();

            // See if the test Vehicles are within the Range
            //foreach (var TV in TestVehicles)
            //{ 
            //    Console.WriteLine(Utils.VehicleIsInBox(TV, new MixTeleMatrix.Rectangle(LatMin, LatMax, LonMin, LonMax)));
            //}

            // Get the vehicle within the shortest distance from the TEST vehicle


        }
    }
}