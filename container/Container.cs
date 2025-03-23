namespace ApbdContainers;

public abstract class Container
{
    private static int _counter;
    public int Height { get; }
    public int Depth { get; }
    public int TareMass { get; }
    public int CargoMass { get; set; }
    public ContainerType Type { get; }
    public string SerialNumber { get; }
    public int MaxPayload { get; }

    protected Container(int height, int depth, int tareMass, int maxPayload, ContainerType type)
    {
        Height = height;
        Depth = depth;
        TareMass = tareMass;
        MaxPayload = maxPayload;
        Type = type;
        
        _counter++;
        SerialNumber = $"KON-{type}-{_counter}";
    }

    protected virtual void EmptyCargo()
    {
        CargoMass = 0;
        Console.WriteLine($"Cargo for {SerialNumber} emptied.");
    }

    protected virtual void FillCargo(int cargoMass)
    {
        if (cargoMass > MaxPayload)
        {
            throw new OverfillException($"{SerialNumber}: Assigned cargo exceeds maximum payload");
        }

        CargoMass = cargoMass;
    }

    protected internal void PrintInfo()
    {
        Console.Write($"{SerialNumber}: ");
        Console.WriteLine($"{Depth}x{Height}cm, mass {TareMass}kg, max payload {MaxPayload}kg, cargo {CargoMass}kg");
    }
    
}