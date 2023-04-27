namespace MixTeleMatrix
{
    public interface IQuadItem
    {
        QuadCollection ChildQuadItem { get; set; }
        Rectangle Quadrant { get; set; }
        List<Vehicle> Vehicles { get; set; }
    }

}