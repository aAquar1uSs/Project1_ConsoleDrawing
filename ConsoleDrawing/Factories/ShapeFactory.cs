using System.Globalization;
using ConsoleDrawing.Models;
using ConsoleDrawing.Tools;

namespace ConsoleDrawing.Factories;

public static class ShapeFactory
{
    /// <summary>
    /// Tries to creating shape.
    /// Supported shapes :
    /// Circle;
    /// Rectangle;
    /// Line;
    /// Square;
    /// Triangle;
    /// </summary>
    /// <param name="number">Number shape.</param>
    /// <returns>Returns requested shape; returns <c>null</c> if shape wasn't resolved.</returns>
    public static Shape? ResolveShapes(int number)
    {
        return number switch
        {
            1 => CreateLine(),
            2 => CreateCircle(),
            3 => CreateTriangle(),
            4 => CreateRectangle(),
            5 => CreateSquare(),
            _ => null
        };
    }
    
    private static Shape? CreateLine()
    {
        Console.WriteLine("Adding line..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y first point coordinate:"); 
        var x1 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y1 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        var point1 = new Point(x1, y1);

        if (!ShapesValidator.PointValidate(point1))
            return null;
        
        Console.WriteLine("Please, input X and Y second point coordinate:"); 
        var x2 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y2 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        var point2 = new Point(x2, y2);

        if (!ShapesValidator.PointValidate(point2))
            return null;
        
        name ??= "Line";
        Console.Clear();
        return new Line(name, point1, point2);
    }

    private static Shape? CreateCircle()
    {
        Console.WriteLine("Adding circle..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y center coordinate:"); 
        var x = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
        var point = new Point(x, y);
        if (!ShapesValidator.PointValidate(point))
            return null;
        
        Console.WriteLine("Enter radius:"); 
        var radius = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("If you want fill shape, enter[y]"); 
        var filled = IsFilled(Console.ReadLine());

        name ??= "Circle";
        Console.Clear();
        var circle = new Circle(name, point, radius, filled);

        return !ShapesValidator.ValidateCircle(circle) ? null : circle;
    }

    private static Shape? CreateRectangle()
    {
        Console.WriteLine("Adding rectangle...");
        Console.WriteLine("Please, enter name:");
        var name = Console.ReadLine();

        Console.WriteLine("Please, input X and Y left upper point coordinate:");
        var x = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
        var y = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        var point = new Point(x, y);
        if (!ShapesValidator.PointValidate(point))
            return null;

        Console.WriteLine("Enter height:");
        var height = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        Console.WriteLine("Enter width:");
        var width = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        Console.WriteLine("If you want fill shape, enter[y]");
        var filled = IsFilled(Console.ReadLine());

        name ??= "Rectangle";
        Console.Clear();

        var rect = new Rectangle(name, new Point(x, y), height, width, filled);

        return !ShapesValidator.ValidateRectangle(rect) ? null : rect;
    }

    private static Shape? CreateSquare()
    {
        Console.WriteLine("Adding square..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y left upper point coordinate:"); 
        var x = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        var point = new Point(x, y);
        if (!ShapesValidator.PointValidate(point))
            return null;
        
        Console.WriteLine("Enter side:"); 
        var side = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        Console.WriteLine("If you want fill shape, enter[y]"); 
        var filled = IsFilled(Console.ReadLine());

        name ??= "Rectangle";
        Console.Clear();

        var square = new Square(name, new Point(x, y), side, filled);

        return !ShapesValidator.ValidateRectangle(square) ? null : square;
    }

    private static Shape? CreateTriangle() 
    {
        Console.WriteLine("Adding triangle..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y first point coordinate:"); 
        var x1 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y1 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        var point1 = new Point(x1, y1);
        if (!ShapesValidator.PointValidate(point1))
            return null;
        
        Console.WriteLine("Please, input X and Y second point coordinate:"); 
        var x2 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y2 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
      
        var point2 = new Point(x2, y2);
        if (!ShapesValidator.PointValidate(point1))
            return null;

        Console.WriteLine("Please, input X and Y third point coordinate:"); 
        var x3 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y3 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
      
        var point3 = new Point(x3, y3);
        if (!ShapesValidator.PointValidate(point3))
            return null;
        
        Console.WriteLine("If you want fill shape, enter[y]"); 
        var filled = IsFilled(Console.ReadLine());

        name ??= "Rectangle";
        Console.Clear();
        return new Triangle(name, point1, point2, point3, filled);
    }

    private static bool IsFilled(string? command)
    {
        return command != null && command.ToLowerInvariant().Equals("y", StringComparison.Ordinal);
    }
}
