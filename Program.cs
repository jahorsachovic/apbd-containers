using ApbdContainers;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Containers!");
        ContainerFactory containerFactory = new ContainerFactory();

        Container liquidContainer= containerFactory.createContainer(200, 300, 500, 1200, ContainerType.L);
        //Container refrigeratedContainer = new Container(300, 400, 750, 750, ContainerType.C);
        Container gasContainer = containerFactory.createContainer(300, 500, 800, 1200, ContainerType.G);
        
        Console.WriteLine("Containers created.");
        liquidContainer.PrintInfo();
        gasContainer.PrintInfo();
    }
}