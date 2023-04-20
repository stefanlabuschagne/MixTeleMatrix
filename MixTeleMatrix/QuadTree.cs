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
            _baseArea = BaseArea;

            // Create 4 Quadrants 

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
