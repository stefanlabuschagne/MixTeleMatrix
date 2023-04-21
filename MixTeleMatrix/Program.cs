using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace MixTeleMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Stopwatch = new Stopwatch();
            Stopwatch.Reset();
            Stopwatch.Start();

            // Load Data
            var AllVehicleList = Utils.LoadVehicleList($"C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\VehiclePositions.dat");

            // Initalize the Quad Tree with the BaseArea
            // Calculate Quadrants
            // Load the vehicles into the Quadrants
            QuadTree QuadTreeStructure = new QuadTree(AllVehicleList);

            // Get test Vehicles
            var TestVehicles = Utils.GetTestVehcles();

            // QT.SanityCheckForTestVehicles(TestVehicles);

            //var Stopwatch = new Stopwatch();
            //Stopwatch.Reset();
            //Stopwatch.Start();

            // Return the closest vehicle to each of the TEST vehicles
            QuadTreeStructure.FindNearestVehicle(TestVehicles);

            Stopwatch.Stop();
            Console.WriteLine ( $"{Stopwatch.ElapsedMilliseconds} milliseconds to complete" , (Stopwatch.ElapsedMilliseconds));

        }

    }
        // Get the vehicle within the shortest distance from the TEST vehicle
}
