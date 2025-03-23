namespace ApbdContainers.ship;
using container;

public class Ship
{
    List<Container> Containers = new();
    int MaxSpeed { get; set; }
    int MaxContainers { get;}
    double MaxWeight { get;}
    private static int _id;

    public Ship(int maxContainers, double maxWeight, int maxSpeed)
    {
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        MaxSpeed = maxSpeed;
        _id++;
    }


    public void AddContainer(Container container)
    {
        if (Containers.Count + 1 > MaxContainers)
        {
            Console.Error.WriteLine($"Can not add more containers to ship {_id}");
        }
        else
        {
            Containers.Add(container);
            Console.WriteLine($"Added {container.SerialNumber}");
        }
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"\nShip: {_id}\n" +
                          $"Max speed: {MaxSpeed}knots\n" +
                          $"Max containers count: {MaxContainers}\n" +
                          $"Max containers weight: {MaxWeight}tons\n" +
                          $"Containers: {Containers}");
    }
    
}