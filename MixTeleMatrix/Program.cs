﻿using System.Collections.Generic;
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

            //Stopwatch.Stop();
            //Console.WriteLine($"{Stopwatch.ElapsedMilliseconds} milliseconds to load", (Stopwatch.ElapsedMilliseconds));


            // Initalize the Quad Tree with the BaseArea
            // Calculate Quadrants according to the grid dimension parameter (# of rows and cols)
            // Load the vehicles into the created Quadrants
            QuadTree QuadTreeStructure = new QuadTree(AllVehicleList,2);

            // Get test Vehicles
            var TestVehicles = Utils.GetTestVehcles();

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
