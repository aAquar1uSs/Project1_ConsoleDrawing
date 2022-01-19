using System.Globalization;
using ConsoleDrawing.Models;

namespace ConsoleDrawing.Services;

public static class ShapeFactory
{
    public static Shape? ResolveShapes(int number)
    {
        return number switch
        {
            1 => null,
            2 => CreateCircle(),
            _ => null
        };
    }

    private static Shape CreateCircle()
    {
        Console.WriteLine("Adding circle..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y center coords:"); 
        var x = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("Enter radius:"); 
        var radius = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("If you want fill shape, enter[y]"); 
        var filled = IsFilled(Console.ReadLine());

        name ??= "Circle";
        Console.Clear();
        return new Circle(name, new Point(x, y), radius, filled);
    }
    
    private static bool IsFilled(string? command)
    {
        return command != null && command.ToLowerInvariant().Equals("y", StringComparison.Ordinal);
    }
}
