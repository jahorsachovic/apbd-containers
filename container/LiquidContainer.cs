namespace ApbdContainers.container;
using util;

public class LiquidContainer : Container, IHazardNotifier
{
    bool IsCargoHazardous;
    
    public LiquidContainer(int height, int depth, int tareMass, int maxPayload)
    : base (height, depth, tareMass, maxPayload, "L")
    {
    }

    public void AddCargo(int cargoMass, bool isCargoHazardous)
    {
        if (isCargoHazardous)
        {
            if (cargoMass + CargoMass > MaxPayload*0.5)
            { 
                ReportHazard();
                Console.Error.WriteLine("Hazardous cargo for can not exceed 50% of max payload.");
            }
        }
        else
        {
            if (cargoMass + CargoMass > MaxPayload*0.9)
            { 
                ReportHazard();
                Console.Error.WriteLine("Normal cargo can not exceed 90% of max payload.");
            }
        }
        if (cargoMass + CargoMass > MaxPayload)
        {
            throw new OverfillException($"{SerialNumber}: Cargo exceeds maximum payload!");
        }
        
        CargoMass = cargoMass + CargoMass;
        IsCargoHazardous = isCargoHazardous;
        Console.WriteLine($"Added cargo to {SerialNumber}.");

    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Hazardous cargo inside: {IsCargoHazardous}\n");
    }

    public void ReportHazard()
    {
        Console.Write($"Hazardous operation detected for {SerialNumber}: ");
    }
}