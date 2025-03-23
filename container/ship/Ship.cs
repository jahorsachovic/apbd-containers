using System.Collections;

namespace ApbdContainers.ship;

public class Ship
{
    private List<Container> containers = new();

    public void AddContainer(Container container)
    {
        containers.Add(container);
        Console.WriteLine($"Added {container.SerialNumber}");
    }
}