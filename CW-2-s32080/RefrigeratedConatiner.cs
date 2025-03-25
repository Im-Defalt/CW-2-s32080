namespace CW_2_s32080;

public class RefrigeratedConatiner : Container, IHazardNotifier
{
    public string ProductType { get; }
    public double Temperature { get; }

    public RefrigeratedConatiner(string productType, double temperature, double loadWeight, double height,
        double ownWeight, double depth, double capacity)
        : base(loadWeight, height, ownWeight, depth, capacity, "C")
    {
        ProductType = productType;
        Temperature = temperature;
    }
    
    public void Warning(string message) => Console.WriteLine($"DANGER: {message}");
    
    public override string toString()
    {
        string s = $"{SerialNumber} (Weight of cargo: {LoadWeight} kg, Weight of container: {OwnWeight} kg, Capacity: {Capacity} kg Height: {Height} cm, Depth: {Depth} cm, Product: {ProductType}, Temperature: {Temperature} Celsius)";
        return s;
    }
    
}