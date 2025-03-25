
using System.Security.AccessControl;
using CW_2_s32080;


class Program
{
    static Dictionary<string, double> refProdTypes = new Dictionary<string, double>() { {"bananas", 13.3}, {"chocolate", 18}, {"fish", 2}, {"meat", -15}, {"ice cream", -18}, {"frozen pizza", -30}, {"cheese", 7.2}, {"sausages", 5}, {"butter", 20.5}, {"eggs", 19} };
    static List<Ship> ships = new();
    static List<Container> containers = new();
    static List<string> actions = ["Exit", "Add ship", "Add container"];
    
    public static void Main(string[] args)
    {
        while (true)
        {
            ShipsInfo();
            Console.WriteLine();
            ContainersInfo();
            Console.WriteLine();


            
            if (ships.Count > 0 && containers.Count > 0)
            {
                actions = ["Exit", "Add ship", "Add container", "Remove ship", "Remove container", "Load ship", "Unload ship", "Load container", "Unload container", "Replace container", "Switch container between ships"];
                ActionsInfo();
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                if (choice >= 0 && choice <= actions.Count)
                {
                    switch (choice)
                    {
                        case 0: Console.WriteLine("Exiting program..."); return;
                        case 1: AddShip(); break;     
                        case 2: AddContainer(); break;
                        case 3: RemoveShip(); break;
                        case 4: RemoveContainer(); break;
                        case 5: LoadShip(); break;
                        case 6: UnloadShip(); break;
                        case 7: LoadContainer(); break;
                        case 8: UnloadContainer(); break;
                        case 9: ReplaceContainer(); break;
                        case 10: SwitchContainerBetweenShips(); break;

                    }
                }
            }else if (ships.Count > 0)
            {
                actions = ["Exit", "Add ship", "Add container", "Remove ship", "Unload ship", "Switch container between ships"];
                ActionsInfo();
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                if (choice >= 0 && choice <= actions.Count)
                {
                    switch (choice)
                    {
                        case 0: Console.WriteLine("Exiting program..."); return;
                        case 1: AddShip(); break;     
                        case 2: AddContainer(); break;
                        case 3: RemoveShip(); break;
                        case 4: UnloadShip(); break;
                        case 5: SwitchContainerBetweenShips(); break;
                            
                    }
                }
            }else if (containers.Count > 0)
            {
                actions = ["Exit", "Add ship", "Add container", "Remove container", "Load container", "Unload container"];
                ActionsInfo();
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                if (choice >= 0 && choice <= actions.Count)
                {
                    switch (choice)
                    {
                        case 0: Console.WriteLine("Exiting program..."); return;
                        case 1: AddShip(); break;     
                        case 2: AddContainer(); break;
                        case 3: RemoveContainer(); break;
                        case 4: LoadContainer(); break;
                        case 5: UnloadContainer(); break;

                    }
                }
            }
            else
            {
                actions = ["Exit", "Add ship", "Add container"];
                ActionsInfo();
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                if (choice >= 0 && choice <= actions.Count)
                {
                    switch (choice)
                    {
                        case 0: Console.WriteLine("Exiting program..."); return;
                        case 1: AddShip(); break;     
                        case 2: AddContainer(); break;

                    }
                }
            }
            

            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadLine();
        }
        
        
        
    }

    public static void ShipsInfo()
    {   
        Console.WriteLine("List of ships:");

        if (ships.Count == 0)
        {
            Console.WriteLine("None");
            return;
        }
        for(int i = 0; i < ships.Count; i++)
        {
            Console.WriteLine($"{i+1}. {ships[i].Name} (Max speed: {ships[i].MaxSpeed} knots, Maximum number of containers: {ships[i].MaxContainerCount}, Maximum cargo weight: {ships[i].MaxWeight} tons)");
            if (ships[i].GetContainers().Count == 0)
            {
                Console.WriteLine("   No containers");
            }
            else
            {
                foreach (Container c in ships[i].GetContainers())
                {
                    Console.WriteLine($"    {c.toString()}");
                }
            }
        }
    }
    public static void ContainersInfo()
    {
        Console.WriteLine("List of containers:");
        if (containers.Count == 0)
        {
            Console.WriteLine("None");
            return;
        }

        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine($"{i+1}. {containers[i].toString()}");

        }
    }
    public static void ActionsInfo()
    {
        Console.WriteLine("Possible actions:");
        for (int i = 0; i < actions.Count; i++)
        {
            Console.WriteLine($"{i}. {actions[i]}");
        }
        
        
    }
    public static void AddShip()
    {
        Console.WriteLine("Provide ship's data");
        Console.WriteLine("Ship's name:");
        string name = Console.ReadLine();
        Console.WriteLine("Ship's max speed in knots:");
        double maxSpeed = double.Parse(Console.ReadLine());
        Console.WriteLine("Ship's max number of containers :");
        int containerCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Ship's max cargo weight in tons:");
        double maxWeight = double.Parse(Console.ReadLine());
        
        ships.Add(new Ship(name, maxSpeed, containerCount, maxWeight));
        Console.WriteLine("New ship has been added");
    }
    public static void RemoveShip()
    {
        ShipsInfo();
        Console.WriteLine("Type the number of the ship you want to delete:");
        int number = int.Parse(Console.ReadLine()) -1;
        if (number < 0 || number > ships.Count)
        {
            Console.WriteLine("Invalid number");
            return;
        }
        ships.RemoveAt(number);
        Console.WriteLine("Ship has been deleted");

    }

    public static void AddContainer()
    {
        Console.WriteLine("Provide weight of the container's load in kg:");
        double loadWeight = double.Parse(Console.ReadLine());
        Console.WriteLine("Provide container's height in cm:");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("Provide container's weight in kg:");
        double ownWeight = double.Parse(Console.ReadLine());
        Console.WriteLine("Provide container's depth in cm:");
        double depth = double.Parse(Console.ReadLine());
        Console.WriteLine("Provide container's capacity in kg:");
        double capacity = double.Parse(Console.ReadLine());
        Console.WriteLine("Provide container's type:");
        string type = Console.ReadLine().ToUpper();

        Container c;
        switch (type)
        {
            case "L":
            {
                Console.WriteLine("Provide whether cargo is hazardous [y/n]:");
                string answer = Console.ReadLine();
                bool isHazardous;
                if (answer == "y")
                {
                    isHazardous = true;
                }
                else if (answer == "n")
                {
                    isHazardous = false;
                }
                else
                {
                    Console.WriteLine("Invalid answer");
                    return;
                }

                c = new LiquidContainer(loadWeight, height, ownWeight, depth, capacity, isHazardous);
                Console.WriteLine("New liquid container has been added");
                break;
            }
            case "G":
            {
                Console.WriteLine("Provide pressure:");
                double pressure = double.Parse(Console.ReadLine());
                c = new GasContainer(pressure, loadWeight, height, ownWeight, depth, capacity);
                Console.WriteLine("New gas conatiner has been added");
                break;
            }
            case "C":
            {
                Console.WriteLine("Provide cargo's product type:");
                string productType = Console.ReadLine().ToLower();
                if (!refProdTypes.ContainsKey(productType))
                {
                    Console.WriteLine("Invalid product type");
                    return;
                }
                Console.WriteLine("Provide container temperature in Celsius:");
                double temperature = double.Parse(Console.ReadLine());
                if (temperature < refProdTypes[productType])
                {
                    Console.WriteLine("Temperature too low for product type");
                    return;
                }
                
                c = new RefrigeratedConatiner(productType, temperature, loadWeight, height, ownWeight, depth, capacity);
                Console.WriteLine("New refrigerated conatiner has been added");
                break;

            }
            default:
                Console.WriteLine("Invalid type");
                return;
        }
        containers.Add(c);

        
    }

    public static void RemoveContainer()
    {
        ContainersInfo();
        Console.WriteLine("Type the  number of the container you want to delete:");
        int containerIndex = int.Parse(Console.ReadLine())-1;
        if (containerIndex < 0 || containerIndex > containers.Count)
        {
            Console.WriteLine("Invalid number");
            return;
        }

        Console.WriteLine($"Container {containers[containerIndex].SerialNumber} has been deleted");
        containers.RemoveAt(containerIndex);
        
    }

    public static void LoadShip()
    {
        Ship shipToLoad;
        List<Container> containersToLoad = new();
        Console.WriteLine("Type the number of the ship you want to load:");
        ShipsInfo();
        int shipIndex = int.Parse(Console.ReadLine())-1;
        if (shipIndex >= 0 && shipIndex < ships.Count)
        {
            shipToLoad = ships[shipIndex];
        }
        else
        {
            Console.WriteLine("Invalid number");
            return;
        }
        
        Console.WriteLine("Type the amount of the containers you want to load:");
        int n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            Console.WriteLine("Type the number of the container you want to load:");
            Console.WriteLine("List of containers:");

            for (int j = 0; j < containers.Count; j++)
            {
                Console.WriteLine($"{j+1}. {containers[j].toString()})");

            }
            int containerNumber = int.Parse(Console.ReadLine())-1;
            shipToLoad.LoadContainer(containers[containerNumber]);
            containers.RemoveAt(containerNumber);
            Console.WriteLine("Container have been loaded");
            return;
        }
        if (n < 1 || n > containers.Count)
        {
            Console.WriteLine("Invalid amount");
            return;
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Type the number of the {i+1} container you want to load:");
            Console.WriteLine("List of containers:");

            for (int j = 0; j < containers.Count; j++)
            {
                Console.WriteLine($"{j+1}. {containers[j].toString()}");

            }
            int containerNumber = int.Parse(Console.ReadLine())-1;
            if (containerNumber >= 0 && containerNumber < containers.Count)
            {
                containersToLoad.Add(containers[containerNumber]);
            }
            
        }
        shipToLoad.LoadContainer(containersToLoad);
        foreach (Container c in containersToLoad)
        {
            containers.Remove(c);
        }
        
        Console.WriteLine("Containers have been loaded");
    }

    public static void UnloadShip()
    {
        Ship shipToUnload;
        List<Container> containersToUnload = new();
        Console.WriteLine("Type the number of the ship you want to unload:");
        ShipsInfo();
        int shipIndex = int.Parse(Console.ReadLine())-1;
        if (shipIndex >= 0 && shipIndex < ships.Count && ships[shipIndex].GetContainers().Count > 0)
        {
            shipToUnload = ships[shipIndex];
        }
        else
        {
            Console.WriteLine("Invalid number");
            return;
        }
        
        Console.WriteLine("Type the number of the containers you want to unload:");
        int n = int.Parse(Console.ReadLine());
        if (n < 1 || n > shipToUnload.GetContainers().Count)
        {
            Console.WriteLine("There is not enough containers to unload");
            return;
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Type the number of the {i+1} container you want to unload:");
            

            for (int j = 0; j < shipToUnload.GetContainers().Count; j++)
            {
                Console.WriteLine($"{j+1}. {shipToUnload.GetContainers()[j].toString()}");
            }
            int containerNumber = int.Parse(Console.ReadLine())-1;
            if (containerNumber >= 0 && containerNumber < containers.Count)
            {
                containersToUnload.Add(shipToUnload.GetContainers()[containerNumber]);
            }
            
        }
        foreach (Container c in containersToUnload)
        {
            shipToUnload.UnloadContainer(c);
            containers.Add(c);
        }
        
        Console.WriteLine("Containers have been unloaded");
    }

    public static void LoadContainer()
    {

        Console.WriteLine($"Type the number of the container you want to load:");
        Console.WriteLine("List of containers:");

        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {containers[i].toString()}");

        }

        int containerNumber = int.Parse(Console.ReadLine()) - 1;
        if (containerNumber >= 0 && containerNumber < containers.Count)
        {
            Console.WriteLine($"Type how much load weight you want to add in kg (load is {containers[containerNumber].LoadWeight}/{containers[containerNumber].Capacity})");
            double containerLoadWeight = double.Parse(Console.ReadLine());
            containers[containerNumber].Load(containerLoadWeight);
            Console.WriteLine("Container have been loaded");
            return;
        }
        Console.WriteLine("Invalid number");
    }

    public static void UnloadContainer()
    {
        Console.WriteLine($"Type the number of the container you want to unload:");
        Console.WriteLine("List of containers:");

        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {containers[i].toString()}");

        }

        int containerNumber = int.Parse(Console.ReadLine()) - 1;
        if (containerNumber >= 0 && containerNumber < containers.Count)
        {
            containers[containerNumber].Unload();
            Console.WriteLine("Container have been unloaded");
            return;
        }
        Console.WriteLine("Invalid number");
        
    }

    public static void ReplaceContainer()
    {
        Console.WriteLine("List of ships:");
        ShipsInfo();
        Console.WriteLine("Type the number of the ship you want to replace container in:");
        int shipIndex = int.Parse(Console.ReadLine())-1;
        if (shipIndex < 0 || shipIndex >= containers.Count)
        {
            Console.WriteLine("Invalid number");
            return;
        }
        Ship shipToReplace = ships[shipIndex];
        if (shipToReplace.GetContainers().Count <= 0)
        {
            Console.WriteLine("There is not enough containers to replace it");
            return;
        }
        Console.WriteLine("Type the number of the container you want to take out:");
        for (int i = 0; i < shipToReplace.GetContainers().Count; i++)
        {
            Console.WriteLine($"{i+1}. {shipToReplace.GetContainers()[i].toString()}");
        }
        int outContainerNumber = int.Parse(Console.ReadLine())-1;
        if (outContainerNumber < 0 || outContainerNumber >= containers.Count)
        {
            Console.WriteLine("Invalid number");
            return;
        }
        Container outContainer = containers[outContainerNumber];
        
        Console.WriteLine("Type the number of the container you want to put instead:");
        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine($"{i+1}. {containers[i].toString()}");
        }
        int inContainerNumber = int.Parse(Console.ReadLine())-1;
        if (inContainerNumber < 0 || inContainerNumber >= containers.Count)
        {
            Console.WriteLine("Invalid number");
            return;
        }
        Container inContainer = containers[inContainerNumber];
        
        shipToReplace.GetContainers().Remove(outContainer);
        shipToReplace.UnloadContainer(outContainer);
        shipToReplace.GetContainers().Add(inContainer);
        shipToReplace.LoadContainer(inContainer);
        
        Console.WriteLine("Containers have been replaced");
        
    }

    public static void SwitchContainerBetweenShips()
    {
        if (ships.Count < 2)
        {
            Console.WriteLine("Not enough ships to conduct this operation");
            return;
        }
        
        Console.WriteLine("List of ships:");
        ShipsInfo();
        Console.WriteLine("Type the number of the ship you want to switch container from:");
        int firstShipIndex = int.Parse(Console.ReadLine()) - 1;
        if (firstShipIndex < 0 || firstShipIndex >= ships.Count)
        {
            Console.WriteLine("Invalid number");
            return;
        }

        if (ships[firstShipIndex].GetContainers().Count <= 0)
        {
            Console.WriteLine("There is not enough containers to conduct this operation");
            return;
        }
        Ship firstShip = ships[firstShipIndex];
        Console.WriteLine("Type the number of the container you want to switch from the ship:");
        for (int i = 0; i < firstShip.GetContainers().Count; i++)
        {
            Console.WriteLine($"{i+1}. {firstShip.GetContainers()[i].toString()}");
        }
        int firstContainerNumber = int.Parse(Console.ReadLine())-1;
        if (firstContainerNumber < 0 || firstContainerNumber >= containers.Count)
        {
            Console.WriteLine("Invalid number");
            return;
        }
        Container containerToSwitch = containers[firstContainerNumber];
        
        
        Console.WriteLine("List of ships:");
        ShipsInfo();
        Console.WriteLine("Type the number of the  ship you want to switch container to:");
        int secondShipIndex = int.Parse(Console.ReadLine()) - 1;
        if (secondShipIndex < 0 || secondShipIndex >= ships.Count)
        {
            Console.WriteLine("Invalid number");
            return;   
        }

        Ship secondShip = ships[secondShipIndex];
        
        firstShip.GetContainers().Remove(containerToSwitch);
        firstShip.UnloadContainer(containerToSwitch);
        
        secondShip.GetContainers().Add(containerToSwitch);
        secondShip.LoadContainer(containerToSwitch);
        
        Console.WriteLine("Container have been switched between ships");
        
    }
}

