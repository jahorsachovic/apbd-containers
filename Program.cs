using ApbdContainers.product;

namespace ApbdContainers;
using ApbdContainers.container;
using ApbdContainers.ship;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Containers!\n");

        LiquidContainer container1 = new LiquidContainer(200, 300, 500, 1200);
        RefrigeratedContainer container2 = new RefrigeratedContainer(300, 400, 750, 750, 18, Product.Sausages);
        GasContainer container3 = new GasContainer(300, 500, 800, 1200);

        Ship ship = new Ship(6, 7.8, 25);
        
        Console.WriteLine("Containers created.\n");
        
        container1.AddCargo(800, true);
        container1.EmptyCargo();
        
        //Uncomment to cause an exception
        //container1.AddCargo(1150, false);
            
        container2.AddCargo(700);
        container3.AddCargo(1200);
        
        container1.PrintInfo();
        container2.PrintInfo();
    }
}