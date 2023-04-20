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

            // Split the base area in 4 segments TL TR BL BR
            _quadLevel = new QuadCollection(BaseArea);

        }
        public bool AddVehicle(Vehicle vehicle)
        {
            // Traverse the tree to add the vehicle somewhere
            Console.WriteLine("Hello World");

            // Check if teh vehicle is in the baseArea


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

        // See if the vehicle is in the box
        private bool VehicleIsInBox(Vehicle vehicle1, Rectangle Box)
        { 
        
            if ( (vehicle1.Latitude <= Box.LatMax) 
                &&(vehicle1.Latitude >= Box.LatMin)
                    && (vehicle1.Longitude <= Box.LonMax)
                        && (vehicle1.Longitude >= Box.LonMin)) 
            { return true; }

            return false;

        }

        // Contains the Split level and the vehicles
        private QuadCollection _quadLevel { get; set; } = null;


    }

}
