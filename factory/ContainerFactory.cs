namespace ApbdContainers;

public class ContainerFactory



{
    public Container createContainer(int height, int depth, int tareMass, int maxPayload, ContainerType type)
    {
        return type switch
        {
            ContainerType.L => new LiquidContainer(height, depth, tareMass, maxPayload, type),
            ContainerType.G => new GasContainer(height, depth, tareMass, maxPayload, type),
            _ => throw new ArgumentException()
        };
    }
}