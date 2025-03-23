namespace ApbdContainers;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(int height, int depth, int tareMass, int maxPayload, ContainerType type)
        : base (height, depth, tareMass, maxPayload, type)
    {
    }
    
    
    
}