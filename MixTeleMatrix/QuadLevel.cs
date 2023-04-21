using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public class QuadCollection
    {
        public QuadCollection(Rectangle BaseArea)
            {    

            // Splits The Passed Area into 4 Smaller Quadrants


            var SA = new List<QuadItem>();
            // TOP LEFT
            var QI = new QuadItem() {
                Quadrant = new MixTeleMatrix.Rectangle(
                            (BaseArea.LatMax + BaseArea.LatMin) / 2,
                            BaseArea.LatMax,
                            BaseArea.LonMin,
                            (BaseArea.LonMax + BaseArea.LonMin) / 2
                            ),
                Vehicles = null,
                ChildQuadItem = null 
            }; 

            SA.Add(QI);

            // TOP RIGHT
            QI = new QuadItem() {
                Quadrant =new MixTeleMatrix.Rectangle(
                            (BaseArea.LatMax+BaseArea.LatMin)/2,
                            BaseArea.LatMax,
                            (BaseArea.LonMax+BaseArea.LonMin)/2 ,
                            BaseArea.LonMax),                                         
                Vehicles = null,
                ChildQuadItem = null
            };

            SA.Add(QI);

            // BOTTOM LEFT
            QI = new QuadItem() {
                Quadrant =  new MixTeleMatrix.Rectangle(
                            BaseArea.LatMin,
                            (BaseArea.LatMax + BaseArea.LatMin) / 2,
                            BaseArea.LonMin,
                            (BaseArea.LonMax + BaseArea.LonMin) / 2),
                Vehicles = null,
                ChildQuadItem = null
            };

            SA.Add(QI);
            // BOTTOM RIGHT


            QI = new QuadItem() {
                Quadrant =  new MixTeleMatrix.Rectangle(
                            BaseArea.LatMin,
                            (BaseArea.LatMax+BaseArea.LatMin)/2,
                            (BaseArea.LonMax+BaseArea.LonMin)/2,
                            BaseArea.LonMax
                            ),
                Vehicles = null,
                ChildQuadItem = null
            };

            SA.Add(QI);

            SplitArea = new List<QuadItem>();
            SplitArea.AddRange(SA);

        }

        // This is the 4 Areas of the Parent Area
        public List<QuadItem> SplitArea { get; set; }
    }

    public class QuadItem
    {

        public Rectangle Quadrant { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();  // Can be null if you have a Leaves (Quadrants)

        public QuadCollection ChildQuadItem { get; set; } 

    }


}
