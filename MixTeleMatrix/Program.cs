using System.Collections.Generic;
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
            // Load Data
            var AllVehicleList = Utils.LoadVehicleList();

            // Initalize the Quad Tree with the BaseArea
            // Calculate Quadrants
            // Load the vehicles into the Quadrants
            QuadTree QT = new QuadTree(AllVehicleList);

            // Get test Vehicles
            List<Vehicle> TestVehicles = Utils.GetTestVehcles();

            // QT.SanityCheckForTestVehicles(TestVehicles);

            // Return the closest vehicle to each of the 10 TEST vehicles
            QT.FindNearestVehicle(TestVehicles);
        }

    }
        // Get the vehicle within the shortest distance from the TEST vehicle
}
