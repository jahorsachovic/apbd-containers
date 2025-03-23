namespace ApbdContainers.ship;
using container;

public class Ship
{
    List<Container> Containers = new();
    int MaxSpeed { get; set; }
    int MaxContainers { get;}
    private double _containerMass;
    double MaxWeight { get;}
    private static int _counter;
    private int _id;

    public Ship(int maxContainers, double maxWeight, int maxSpeed)
    {
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        MaxSpeed = maxSpeed;
        _id = ++_counter;
    }


    public void AddContainer(Container container)
    {
        
        if (IsContainerOnThisShip(container))
        {
            Console.WriteLine($"Ship {_id}: Container {container.SerialNumber} is already here.");
        }
        else if (container.Assigned)
        {
            Console.WriteLine($"Ship {_id}: Container {container.SerialNumber} is assigned on a different ship.");
        } 
        else if (Containers.Count + 1 > MaxContainers)
        {
            Console.Error.WriteLine($"Ship {_id}: Can not add more containers.");
        }
        else if (CalculateLoad() + container.CargoMass + container.TareMass > MaxWeight * 1000)
        {
            Console.Error.WriteLine($"Ship {_id}: Can not add container {container.SerialNumber}. Ship is overweight.");
        }
        else {
            Containers.Add(container);
            container.Assigned = true;
            Console.WriteLine($"Ship {_id}: Added {container.SerialNumber}");
        }
    }

    public void RemoveContainer(Container container)
    {
        if (Containers.Contains(container))
        {
            Containers.Remove(container);
            container.Assigned = false;
        } else
        {
            Console.WriteLine($"Ship {_id}: There is no {container.SerialNumber} on this ship.");
        } 
    }

    public void TransferContainer(Container container, Ship destinationShip)
    {
        RemoveContainer(container);
        destinationShip.AddContainer(container);
    }

    public void ReplaceContainer(Container replacedContainer, Container addedContainer)
    {
        RemoveContainer(replacedContainer);
        replacedContainer.Assigned = false;
        AddContainer(addedContainer);
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"\nShip: {_id}\n" +
                          $"Max speed: {MaxSpeed}knots\n" +
                          $"Max containers count: {MaxContainers}\n" +
                          $"Max containers weight: {MaxWeight}tons\n" +
                          $"Containers: {string.Join(", ", Containers)}\n" +
                          $"Load: {CalculateLoad()}");
    }

    private double CalculateLoad()
    {
        _containerMass = 0;
        foreach (var con in Containers)
        {
            _containerMass += con.TareMass + con.CargoMass;
            //Debug line for checking calculations
            //Console.WriteLine($"After {con.SerialNumber} it's {_containerMass}");
        }
        
        return _containerMass;
    }

    private bool IsContainerOnThisShip(Container container)
    {
        foreach (Container con in Containers)
        {
            if (con.SerialNumber.Equals(container.SerialNumber) )
            {
                return true;
            }
        }
        
        return false;
    }
    
}