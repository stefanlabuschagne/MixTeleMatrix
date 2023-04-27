namespace MixTeleMatrix
{
    public interface IVehicle
    {
        float Latitude { get; set; }
        float Longitude { get; set; }
        int Positionid { get; set; }
        ulong RecordedTimeUTC { get; set; }
        string VehicleRegistration { get; set; }
    }
}