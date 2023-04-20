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
            var SplitArea = new List<QuadItem>();
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

            SplitArea.Add(QI);

            // TOP RIGHT
            QI = new QuadItem() {
                Quadrant =new MixTeleMatrix.Rectangle(
                            (BaseArea.LatMax+BaseArea.LatMin)/2,
                            BaseArea.LatMax,
                            (BaseArea.LonMax+BaseArea.LonMin)/2 ,
                            BaseArea.LonMax),                                         ) 
                Vehicles = null,
                ChildQuadItem = null
            };

            SplitArea.Add(QI);

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

            SplitArea.Add(QI);
            // BOTTOM RIGHT


                var QI = new QuadItem() {
                    Quadrant =  new MixTeleMatrix.Rectangle(
                                BaseArea.LatMin,
                                (BaseArea.LatMax+BaseArea.LatMin)/2,
                                (BaseArea.LonMax+BaseArea.LonMin)/2,
                                BaseArea.LonMax
                                ),
                    Vehicles = null,
                    ChildQuadItem = null
                };

            SplitArea.Add(QI);


            {
            //_QuadLevel.Quadrants = new List<Rectangle>()
            //{
            //    new MixTeleMatrix.Rectangle(
            //                                (BaseArea.LatMax+BaseArea.LatMin)/2,
            //                                BaseArea.LatMax,
            //                                BaseArea.LonMin,
            //                                (BaseArea.LonMax+BaseArea.LonMin)/2
            //                                ),
            //    new MixTeleMatrix.Rectangle(
            //                                (BaseArea.LatMax+BaseArea.LatMin)/2,
            //                                BaseArea.LatMax,
            //                                (BaseArea.LonMax+BaseArea.LonMin)/2 ,
            //                                BaseArea.LonMax
            //                                ) ,
            //    new MixTeleMatrix.Rectangle(
            //                                 BaseArea.LatMin,
            //                                (BaseArea.LatMax+BaseArea.LatMin)/2,
            //                                 BaseArea.LonMin ,
            //                                (BaseArea.LonMax+BaseArea.LonMin)/2
            //                                ) ,
            //    new MixTeleMatrix.Rectangle(
            //                                BaseArea.LatMin,
            //                                (BaseArea.LatMax+BaseArea.LatMin)/2,
            //                                (BaseArea.LonMax+BaseArea.LonMin)/2,
            //                                BaseArea.LonMax
            //                                )
            //};
        }


        // This is the 4 Areas of the Parent Area
        public List<QuadItem> SplitArea { get; set; } = null;

    }

    public class QuadItem
    {

        public Rectangle Quadrant { get; set; } = null;

        public List<Vehicle> Vehicles { get; set; } = null; // Can be null if you have a Leaves (Quadrants)

        public QuadCollection ChildQuadItem { get; set; } = null;

    }


}
