using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTeleMatrix
{
    public class Vehicle
    {
       public Int32 Positionid { get; set; } // Signed 32-bit integer (32 bits)

        public string VehicleRegistration { get; set; } // Null Terminated ASCII String 00000000 00000000

        public float Latitude { get; set; }   // 4 bytes (32 bits)

        public float Longitude { get; set; } // 4 bytes (32 bits)

        public UInt64 RecordedTimeUTC { get; set; }  // 8 Bytes (64bits)
    }
}
