namespace CW_2_s32080;

public abstract class Container
{
    public double LoadWeight { get; protected set; } //in kg
    public double Height { get; } //in cm
    public double OwnWeight{ get; } //in kg
    public double Depth{ get; } //in cm
    public string SerialNumber{ get; } // KON-type-number
    public double Capacity{ get; } //in kg
    public string Type{ get; }
    protected static int Counter = 1;

    protected Container(double loadWeight, double height, double ownWeight, double depth, double capacity, string type)
    {
        LoadWeight = loadWeight;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        SerialNumber = $"KON-{type}-{Counter++}";
        Capacity = capacity;
        Type = type;
    }

    public virtual void Load(double load)
    {
        if (LoadWeight+ load > Capacity)
        {
            throw new OverfillException($"Cannot load {load} because it is too much");
        }
        LoadWeight += load;
    }
    public virtual void Unload()
    {
        LoadWeight = 0;
    }
    
    public virtual string toString()
    {
        string s = $"{SerialNumber} (Weight of cargo: {LoadWeight} kg, Weight of container: {OwnWeight} kg, Capacity: {Capacity} kg Height: {Height} cm, Depth: {Depth} cm)";
        return s;
    }


    
}