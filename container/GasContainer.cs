namespace ApbdContainers.container;
using util;

public class GasContainer : Container, IHazardNotifier
{
    private int Pressure { get; }
    
    public GasContainer(int height, int depth, int tareMass, int maxPayload, int pressure)
        : base (height, depth, tareMass, maxPayload, "G")
    {
        Pressure = pressure;

    }

    public override void EmptyCargo()
    {
        CargoMass *= 0.05;
        Console.WriteLine($"Cargo for {SerialNumber} emptied. {CargoMass}kg left inside.");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Pressure: {Pressure}Pa\n");
    }

    public void ReportHazard()
    {
        throw new NotImplementedException();
    }
}