using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Linq;

namespace MixTeleMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //byte[] fileBytes = File.ReadAllBytes($"C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\VehiclePositions.dat");
            //StringBuilder sb = new StringBuilder();

            //foreach (byte b in fileBytes)
            //{
            //    sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            //    // Console.WriteLine(sb.ToString());
            //}

            //File.WriteAllText("C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\DecentData", sb.ToString());

            //string filePath = $"C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\VehiclePositions.dat";
            //Encoding encoding = Encoding.UTF8; // or any other encoding you want to use
            //int bufferSize = 1024 * 1024; // read the file in chunks of 1 MB

            //using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //using (var binaryReader = new BinaryReader(fileStream))
            //{
            //    var stringBuilder = new StringBuilder();
            //    byte[] buffer;
            //    do
            //    {
            //        buffer = binaryReader.ReadBytes(bufferSize);
            //        stringBuilder.Append(encoding.GetString(buffer));
            //    } while (buffer.Length == bufferSize);

            //    string result = stringBuilder.ToString();
            //    Console.WriteLine(result);
            //}

            // Open the file stream and create a BinaryFormatter instance
            //using (FileStream fileStream = new FileStream($"C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\VehiclePositions.dat", FileMode.Open))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();

            //    // Deserialize the binary data into a MyData object
            //    Reading data = (Reading)formatter.Deserialize(fileStream);

            //    // Use the deserialized data
            //    Console.WriteLine($"Value1: {data.VehicleRegistration}");
            //    Console.WriteLine($"Value2: {data.Latitude}");
            //    Console.WriteLine($"Value2: {data.Longitude}");
            //    Console.WriteLine($"=========================");
            //}

            var daReaingList = new List<Reading>();


            using (var stream = File.Open($"C:\\Users\\stefa\\downloads\\vehiclepositions_datafile\\VehiclePositions.dat", FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    var daReaing = new Reading();

                    daReaing.Positionid = reader.ReadInt32();
                    char c = reader.ReadChar();
                    while (c != '\0')
                    {
                        daReaing.VehicleRegistration = daReaing.VehicleRegistration + c;
                        c = reader.ReadChar();
                    }
                    daReaing.Latitude = reader.ReadSingle();
                    daReaing.Longitude = reader.ReadSingle();
                    daReaing.RecordedTimeUTC = (ulong)reader.ReadInt64();

                    daReaingList.Add(daReaing);

                }

            }
        }
    }
}