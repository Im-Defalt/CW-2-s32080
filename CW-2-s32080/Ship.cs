namespace CW_2_s32080;

public class Ship
{
    public string Name { get; }
    private List<Container> containers = new();
    public double MaxSpeed { get; } //in knots
    public int MaxContainerCount { get; }
    public double MaxWeight { get; } //in tons

    public Ship(string name, double maxSpeed, int maxContainerCount, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }
    
    public List<Container> GetContainers() => containers;

    public double TotalWeight() => containers.Sum(c => c.LoadWeight + c.OwnWeight);

    public void LoadContainer(Container c)
    {
        if (containers.Count + 1 >= MaxContainerCount)
        {
            throw new Exception("Too many containers");
        }
        if (TotalWeight() + c.OwnWeight + c.LoadWeight > MaxWeight)
        {
            throw new Exception("Maximum load weight exceeded");
        }
        containers.Add(c);
    }

    public void LoadContainer(List<Container> containersToLoad)
    {
        if (containers.Count + containersToLoad.Count >= MaxContainerCount)
        {
            throw new Exception("Too many containers");
        }

        if (TotalWeight() + containersToLoad.Sum(c => c.LoadWeight + c.OwnWeight) > MaxWeight*1000)
        {
            throw new Exception("Maximum load weight exceeded");
        }
        containers.AddRange(containersToLoad);
    }

    public void UnloadContainer(Container c)
    {
        containers.Remove(c);
    }
    
    
}