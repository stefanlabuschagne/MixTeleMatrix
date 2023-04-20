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

        public QuadTree(MixTeleMatrix.Rectangle BaseArea)
        {
            // Accept the Base Area
            _baseArea = BaseArea;

            // Create 4 Quadrants (TL,TR, BL, BR)
            Quadrants = new List<Rectangle>() 
            { 
                new MixTeleMatrix.Rectangle(
                                            (BaseArea.LatMax+BaseArea.LatMin)/2,
                                            BaseArea.LatMax,
                                            BaseArea.LonMin,
                                            (BaseArea.LonMax+BaseArea.LonMin)/2
                                            ),
                new MixTeleMatrix.Rectangle(
                                            (BaseArea.LatMax+BaseArea.LatMin)/2,
                                            BaseArea.LatMax,
                                            (BaseArea.LonMax+BaseArea.LonMin)/2 ,
                                            BaseArea.LonMax
                                            ) ,
                new MixTeleMatrix.Rectangle(
                                             BaseArea.LatMin,
                                            (BaseArea.LatMax+BaseArea.LatMin)/2,
                                             BaseArea.LonMin ,
                                            (BaseArea.LonMax+BaseArea.LonMin)/2
                                            ) ,
                new MixTeleMatrix.Rectangle(
                                            BaseArea.LatMin,
                                            (BaseArea.LatMax+BaseArea.LatMin)/2,
                                            (BaseArea.LonMax+BaseArea.LonMin)/2,
                                            BaseArea.LonMax
                                            ) 
            };
        }
        public void AddVehicle(Vehicle vehicle)
        {
            // Traverse the tree to add the vehicle somewhere
            Console.WriteLine("Hello World");

            // Decide in which Quadrat to Add the Vehicle

        }

        public Vehicle GetNearsestVehicle(Vehicle vehicle)
        {
            // Look for the quadrant with the nearest vehicle
            return new Vehicle() { };
        }

        private int calculateDistance(Vehicle vehicle1, Vehicle vehicle2)
        {
            // Calculate the Distance
            return 100;
        }


        public List<Rectangle> Quadrants { get; set; } = null;

        public List<Vehicle> Vehicles { get; set; } = null; // Can be null if you have a Leaves (Quadrants)

    }

}
