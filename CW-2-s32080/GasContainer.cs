namespace CW_2_s32080;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(double pressure, double loadWeight, double height, double ownWeight, double depth, double capacity)
        : base(loadWeight, height, ownWeight, depth, capacity, "G")
    {
        Pressure = pressure;
    }


    public override string toString()
    {
        string s = $"{SerialNumber} (Weight of cargo: {LoadWeight} kg, Weight of container: {OwnWeight} kg, Capacity: {Capacity} kg Height: {Height} cm, Depth: {Depth} cm, Pressure: {Pressure})";
        return s;
    }

    public override void Unload()
    {
        LoadWeight = LoadWeight * 0.05;
        Warning($"Gas container {SerialNumber} after unloading still has 5% of its load");
    }
    
    public void Warning(string message) => Console.WriteLine($"DANGER: {message}");

}