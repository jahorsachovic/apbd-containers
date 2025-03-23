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
        //Uncomment to cause an exception due to low temperature
        //RefrigeratedContainer test = new RefrigeratedContainer(300, 400, 750, 750, -5, Product.Sausages);
        GasContainer container3 = new GasContainer(300, 500, 800, 1200, 240000);

        Ship ship = new Ship(6, 7.8, 25);
        Ship ship2 = new Ship(4, 5.3, 20);
        
        Console.WriteLine("Containers created.\n");
        
        
        //Uncomment to cause a hazard
        /*container1.AddCargo(800, true);
        container1.EmptyCargo();
        container1.AddCargo(1150, false);*/
        
        
        
        container1.AddCargo(800, false);    
        container2.AddCargo(700);
        container3.AddCargo(1200);
        //Uncomment to cause an OverfillException
        //container3.AddCargo(300);
        
        container1.PrintInfo();
        container2.PrintInfo();
        container3.PrintInfo();
        
        ship.AddContainer(container1);
        ship.AddContainer(container2);
        ship.AddContainer(container3);
        ship.AddContainer(container3);
        
        ship.PrintInfo();
        ship.TransferContainer(container1, ship2);
        ship.RemoveContainer(container3);
        ship2.ReplaceContainer(container1, container3);
        ship2.PrintInfo();
    }
}