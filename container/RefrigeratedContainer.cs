using ApbdContainers.product;

namespace ApbdContainers.container;

public class RefrigeratedContainer : Container
{
    private static readonly Dictionary<Product,double> _productTemp = new()
    {
        { Product.Bananas, 13.3 },
        { Product.Chocolate, 18 },
        { Product.Fish, 2 },
        { Product.Meat, -15 },
        { Product.IceCream, -18 },
        { Product.Pizza, -30 },
        { Product.Cheese, 7.2 },
        { Product.Sausages, 5 },
        { Product.Butter, 20.5 },
        { Product.Eggs, 19 }
    };

    private readonly Product _product;

    private double Temperature;

    public RefrigeratedContainer(int height, int depth, int tareMass, int maxPayload, double temperature, Product product)
        : base(height, depth, tareMass, maxPayload, "C")
    {
        Temperature = temperature;
        _product = product;

        if (Temperature < _productTemp[product])
        {
            throw new ArgumentException($"The temperature inside the container can not be lower than {_productTemp[product]} for {product}");
        }

    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Product type: {_product}\n");
    }
}