namespace CW_2_s32080;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer
        (double loadWeight, double height, double ownWeight, double depth, double capacity, bool isHazardous) 
        : base(loadWeight, height, ownWeight, depth, capacity, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double load)
    {
        double maxLoad;
        if (IsHazardous)
        {
            maxLoad = Capacity * 0.5;
        }
        else
        {
            maxLoad = Capacity*0.9;
        }

        if (load > maxLoad)
        {
            while (true){
                Warning($"Attempt to overfill container {SerialNumber}");
                Console.WriteLine($"Do you wish to continue? [y/n]");
                string decision = Console.ReadLine().ToLower();
                if (decision == "n")
                    return;
                if (decision == "y")
                {
                    base.Load(load);
                    return;
                }
                Console.WriteLine($"Invalid input: {decision}");
            }

        }
    }
    
    public void Warning(string message) => Console.WriteLine($"DANGER: {message}");
    
    public override string toString()
    {
        string s;
        if (IsHazardous)
        {
            s = $"{SerialNumber} (Weight of cargo: {LoadWeight} kg, Weight of container: {OwnWeight} kg, Capacity: {Capacity} kg Height: {Height} cm, Depth: {Depth} cm, Is Hazardous: Yes)";

        }
        else
        {
            s = $"{SerialNumber} (Weight of cargo: {LoadWeight} kg, Weight of container: {OwnWeight} kg, Capacity: {Capacity} kg Height: {Height} cm, Depth: {Depth} cm, Is Hazardous: No)";

        }
        return s;
    }
    
}