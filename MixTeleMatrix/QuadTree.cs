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

        public QuadTree(MixTeleMatrix.Rectangle BaseArea)
        {
            // Accept the Base Area
            _baseArea = BaseArea;

            // Split the base area in 4 segments TL TR BL BR
            _quadLevel = new QuadCollection(BaseArea);

        }
        public bool AddVehicle(Vehicle vehicle)
        {

            if (VehicleIsInBox(vehicle, _baseArea)) 
            { 
            
                foreach (var Quadrant in _quadLevel.SplitArea) 
                {
                    if (VehicleIsInBox(vehicle, Quadrant.Quadrant))
                    { 
                        Quadrant.Vehicles.Add(vehicle);
                        return true;
                    }

                }
            
            }
            return false;

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
        private bool VehicleIsInBox(Vehicle vehicle1, MixTeleMatrix.Rectangle Box)
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
