﻿using MixTeleMatrix;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public class QuadTree
    {
        readonly Rectangle _baseArea;

        public QuadTree(List<Vehicle> daVehicleList)
        {
            // Calculate the Base Area
            _baseArea = (Utils.CalculateAreaRectangle(daVehicleList));

            // Split the base area in even Grid QUADRANTS (even amounts of rows and Colums)
            // This can be increased if we want more quadrants (for a faster lookup time)
            // but the preparation time is more, having more quadrants to 
            // For more Test Vehicles
            _quadLevel = new QuadCollection(_baseArea,16);

            // Add The Vehicles to the respective Quadrants
            AddVehicleToQuadrants(daVehicleList);
        }

        public void SanityCheckForTestVehicles(List<Vehicle> testVehicles)
        {
            Console.WriteLine("BaseArea;");
            Console.WriteLine(_baseArea.LatMin + " x " + _baseArea.LatMax + " x " + _baseArea.LonMin + " x " + _baseArea.LonMax);

            foreach (var v in testVehicles)
            {

                Console.WriteLine("Vehicle;");
                Console.WriteLine(v.Latitude + " x " + v.Longitude);

                if (Utils.VehicleIsInArea(v, _baseArea))
                {

                }
                else
                {
                    Console.WriteLine("Test Vehicle Out of Bounds!");
                }
            }

        }

        private void AddVehicleToQuadrants(List<Vehicle> VehicleList)
        {
            foreach (var Vehicle in VehicleList)
            {
                AddVehicle(Vehicle);
            }
        }

        private bool AddVehicle(Vehicle vehicle)
        {

            if (Utils.VehicleIsInArea(vehicle, _baseArea))
            {

                foreach (var Quadrant in _quadLevel.SplitAreas)
                {
                    if (Utils.VehicleIsInArea(vehicle, Quadrant.Quadrant))
                    {
                        if (Quadrant.Vehicles == null) { Quadrant.Vehicles = new List<Vehicle>(); }
                        Quadrant.Vehicles.Add(vehicle);
                        return true;
                    }

                }

            }
            return false;

        }

        public void FindNearestVehicle(List<Vehicle> TestVehicles)
        {
            foreach (var CurrentTestVehicle in TestVehicles)
            {

                Console.WriteLine($"Looking Around Vehicle: Lat: {CurrentTestVehicle.Latitude} Long: {CurrentTestVehicle.Longitude}");

                var ClosestVehicle = GetNearestVehicle(CurrentTestVehicle);

                Console.WriteLine($"Found Vehicle:          Lat: {ClosestVehicle.Latitude} Long: {ClosestVehicle.Longitude}");
                //Console.WriteLine(ClosestVehicle.VehicleRegistration);
                Console.WriteLine("");
            }
        }

        private Vehicle GetNearestVehicle(Vehicle vehicle)
        {
            // Look for the quadrant with the nearest vehicle
            double MinDistance = 0;
            var ReturnVehicle = new Vehicle();

            foreach (var QuadrantArea in _quadLevel.SplitAreas)
            {
                if (Utils.VehicleIsInArea(vehicle, QuadrantArea.Quadrant))
                {

                    //Console.WriteLine("Vehicle in quadrant - Entering Quadrant");
                    
                    // Calculate Distances for all the vehicles
                    foreach( Vehicle V in QuadrantArea.Vehicles) 
                    {
                        double VehicleDistance =  Utils.CalculateDistance(vehicle, V);
                        if ( (MinDistance == 0) || (VehicleDistance < MinDistance)  )
                        {
                            ReturnVehicle = V;
                            MinDistance = VehicleDistance;

                            //Console.WriteLine("Found Vehicle");
                        }
                    }

                    // Do we need to check adjacent Quadrants
                    // For closer vehicles??
                    var TopDistance = (QuadrantArea.Quadrant.LatMax - ReturnVehicle.Latitude);
                    var BotDistance = (ReturnVehicle.Latitude - QuadrantArea.Quadrant.LatMin);

                    var LeftDistance = (ReturnVehicle.Longitude - QuadrantArea.Quadrant.LonMin);
                    var RightDistance = (QuadrantArea.Quadrant.LonMax - ReturnVehicle.Longitude);

                    // Any of these are smaller than MinDistance
                    // then we need to search in another Quadrant 
                    if ( 
                        (TopDistance < MinDistance) || 
                        (BotDistance < MinDistance) || 
                        (LeftDistance < MinDistance) || 
                        (RightDistance < MinDistance) )
                        {
                            // TODO
                            Console.WriteLine("Not the nearest vehicle - look in adjacent Quadrant");    

                        }

                    return (ReturnVehicle);

                }
                else
                { 
                    
                    // Console.WriteLine("Vehicle not in quadrant"); 
                
                }

            }

            // Sanity Check for other quadrants
            return (ReturnVehicle);

        }

        // Contains the Split level and the vehicles
        private QuadCollection _quadLevel { get; set; } = null;

    }

}
