﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public class QuadCollection
    {
        // Splits The Passed Area into Smaller Quadrants
        // As specified by the gridDimensions
        // The more quadrants the quicker the lookup time
        public QuadCollection(Rectangle BaseArea, int gridDimensions)
            {

            float ColIncrement = (BaseArea.LatMax - BaseArea.LatMin)/ gridDimensions;
            float RowIncrement = (BaseArea.LonMax - BaseArea.LonMin)/ gridDimensions;

            SplitAreas = new List<QuadItem>();
            SplitAreas.Capacity = gridDimensions * gridDimensions;

            float R = BaseArea.LonMin; // LONGITUDES  (Left to Right Loop)
            for (var Row = 1; Row <= gridDimensions; Row++)
            {

                float C = BaseArea.LatMin; // LATITUDES  (Bottom Up Loop)
                for (var Col = 1; Col <= gridDimensions; Col++)
                {

                    SplitAreas.Add(
                        new QuadItem()
                        {
                            // mlatmin latmax, lonmin, lonmax
                            Quadrant = new MixTeleMatrix.Rectangle(C,
                                                                C + ColIncrement,
                                                                R,
                                                                R + RowIncrement),
                            Vehicles = new List<Vehicle>(),
                            ChildQuadItem = null
                        });

                    C += ColIncrement;

                }

                R += RowIncrement;

            }

        }

        // This is the Areas of the Parent Area
        public List<QuadItem> SplitAreas { get; }
    }

    public class QuadItem : IQuadItem
    {

        public Rectangle Quadrant { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();  // Can be null if you have a Leaves (Quadrants)

        public QuadCollection ChildQuadItem { get; set; }  // OBSOLETE WITH THIS SOLUTION

    }

}
