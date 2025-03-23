namespace ApbdContainers.container;
using util;

public abstract class Container
{
    private static int _counter;
    private static int Height { get; set; }
    private static int Depth { get; set; }
    public double TareMass { get; }
    public double CargoMass { get; set; }
    public string SerialNumber { get; }
    protected double MaxPayload { get; }
    public bool Assigned { get; set; }

    protected Container(int height, int depth, double tareMass, double maxPayload, string type)
    {
        Height = height;
        Depth = depth;
        TareMass = tareMass;
        MaxPayload = maxPayload;
        
        _counter++;
        SerialNumber = $"KON-{type}-{_counter}";
    }

    public virtual void EmptyCargo()
    {
        CargoMass = 0;
        Console.WriteLine($"Cargo for {SerialNumber} emptied.");
    }

    public virtual void AddCargo(int cargoMass)
    {
        if (cargoMass + CargoMass > MaxPayload)
        {
            throw new OverfillException($"{SerialNumber}: Cargo exceeds maximum payload.");
        }
        
        CargoMass = cargoMass + cargoMass;
        Console.WriteLine($"Added cargo to {SerialNumber}.");
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"\nContainer: {SerialNumber}\n" +
                          $"Height: {Height}cm\n" +
                          $"Depth: {Depth}cm\n" +
                          $"Tare mass: {TareMass}kg\n" +
                          $"Max payload: {MaxPayload}kg\n" +
                          $"Current payload: {CargoMass}kg");
    }

    public override string ToString()
    {
        return $"{SerialNumber}";
    }
}