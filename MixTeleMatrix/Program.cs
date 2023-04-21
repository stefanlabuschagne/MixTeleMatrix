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
            
            // Get Test Vehicles
            var TestVehicles = Utils.GetTestVehcles();

            //Stopwatch.Stop();
            //Console.WriteLine($"{Stopwatch.ElapsedMilliseconds} milliseconds to load", (Stopwatch.ElapsedMilliseconds));

            // 1 - Initalize the Quad Tree with the BaseArea
            // 2-  Calculate Quadrants according to the Grid-Dimension-Parameter (# of rows and cols)
            // 3 - Load the vehicles into the created Quadrants
            int GridDimensionParameter = 2;
            QuadTree QuadTreeStructure = new QuadTree(AllVehicleList,GridDimensionParameter);

         /*
            Stopwatch = new Stopwatch();
            Stopwatch.Reset();
            Stopwatch.Start();
         */
            // Return the closest vehicle to each of the TEST vehicles
            QuadTreeStructure.FindNearestVehicle(TestVehicles);

            Stopwatch.Stop();
            Console.WriteLine ( $"{Stopwatch.ElapsedMilliseconds} milliseconds to lookup" , (Stopwatch.ElapsedMilliseconds));

        }

    }
    // Get the vehicle within the shortest distance from the TEST vehicle
}
