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
            // IMPORTANT PARAMETERS!!
            string DatFileLocation = $"C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\VehiclePositions.dat";
            int GridDimensionParameter = 8;

            var Stopwatch = new Stopwatch();
            Stopwatch.Reset();
            Stopwatch.Start();
            Console.WriteLine($"{Stopwatch.ElapsedMilliseconds} milliseconds - Starting.");

            // Load Data
            var AllVehicleList = Utils.LoadVehicleList(DatFileLocation);
            
            // Load Test Vehicles
            var TestVehicles = Utils.GetTestVehcles();

            Console.WriteLine($"{Stopwatch.ElapsedMilliseconds} miliseconds - Loadng Source Data Done.");

            // 1 - Initalize the Quad Tree with the BaseArea
            // 2-  Calculate Quadrants according to the Grid-Dimension-Parameter (# of rows and cols)
            // 3 - Load the vehicles into the created Quadrants
            QuadTree QuadTreeStructure = new QuadTree(AllVehicleList,GridDimensionParameter);

            Console.WriteLine($"{Stopwatch.ElapsedMilliseconds} miliseconds - Populating Grid {GridDimensionParameter} X {GridDimensionParameter} Done.");

            // Return the closest vehicle to each of the TEST vehicles
            QuadTreeStructure.FindNearestVehicle(TestVehicles);

            Stopwatch.Stop();
            Console.WriteLine ( $"{Stopwatch.ElapsedMilliseconds} millisecnds - Calculated nearest vehicles Done." , (Stopwatch.ElapsedMilliseconds));
            Console.ReadLine ();

        }

    }
    // Get the vehicle within the shortest distance from the TEST vehicle
}
