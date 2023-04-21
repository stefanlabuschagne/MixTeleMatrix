using MixTeleMatrix;
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

            // Split the base area in 4 segments TL TR BL BR
            _quadLevel = new QuadCollection(_baseArea);

            // Add The Vehicles to the respective quadrants
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

                if (Utils.VehicleIsInRectangle(v, _baseArea))
                {

                }
                else
                {
                    Console.WriteLine("Vehicle Out of Bounds!");
                }
            }

        }

        private void AddVehicleToQuadrants(List<Vehicle> daVehicleList)
        {
            foreach (var v in daVehicleList)
            {
                AddVehicle(v);
            }
        }

        private bool AddVehicle(Vehicle vehicle)
        {

            if (Utils.VehicleIsInRectangle(vehicle, _baseArea))
            {

                foreach (var Quadrant in _quadLevel.SplitArea)
                {
                    if (Utils.VehicleIsInRectangle(vehicle, Quadrant.Quadrant))
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

                Console.WriteLine("Looking Around Vehicle: Lat: " + CurrentTestVehicle.Latitude + " Long: "+ CurrentTestVehicle.Longitude);

                var ClosestVehicle = GetNearestVehicle(CurrentTestVehicle);

                Console.WriteLine("Found Vehicle:          Lat: " + ClosestVehicle.Latitude + " Long: " + ClosestVehicle.Longitude);
                //Console.WriteLine(ClosestVehicle.VehicleRegistration);
                Console.WriteLine("");
            }
        }

        private Vehicle GetNearestVehicle(Vehicle vehicle)
        {
            // Look for the quadrant with the nearest vehicle
            double MinDistance = 0;
            var ReturnVehicle = new Vehicle();

            foreach (var QuadrantArea in _quadLevel.SplitArea)
            {
                if (Utils.VehicleIsInRectangle(vehicle, QuadrantArea.Quadrant))
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

            // Iterate through the Quad Collection
            // Get the right quadrannt
            // Compare all vehicles in the quadrant with passed vehicle

            // Check if you need to check other quadrants as well.....


            return new Vehicle() { };
        }

        // Contains the Split level and the vehicles
        private QuadCollection _quadLevel { get; set; } = null;

    }

}
