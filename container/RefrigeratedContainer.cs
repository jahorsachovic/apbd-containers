namespace ApbdContainers;

public class RefrigeratedContainer : Container
{
    public RefrigeratedContainer(int height, int depth, int tareMass, int maxPayload, ContainerType type)
        : base(height, depth, tareMass, maxPayload, type)
    {
    }
}