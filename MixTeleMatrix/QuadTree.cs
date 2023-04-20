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

            if (Utils.VehicleIsInBox(vehicle, _baseArea)) 
            { 
            
                foreach (var Quadrant in _quadLevel.SplitArea) 
                {
                    if (Utils.VehicleIsInBox(vehicle, Quadrant.Quadrant))
                    {
                        if (Quadrant.Vehicles == null) { Quadrant.Vehicles = new List<Vehicle>(); }
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

        

        // Contains the Split level and the vehicles
        private QuadCollection _quadLevel { get; set; } = null;

    }

}
