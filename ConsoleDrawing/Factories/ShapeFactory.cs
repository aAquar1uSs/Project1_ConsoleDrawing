﻿using System.Globalization;
using ConsoleDrawing.Models;

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

    private static Shape CreateCircle()
    {
        Console.WriteLine("Adding circle..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y center coordinate:"); 
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

    private static Shape CreateRectangle()
    {
        Console.WriteLine("Adding rectangle..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y left upper point coordinate:"); 
        var x = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("Enter height:"); 
        var height = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("Enter width:"); 
        var width = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 

        
        Console.WriteLine("If you want fill shape, enter[y]"); 
        var filled = IsFilled(Console.ReadLine());

        name ??= "Rectangle";
        Console.Clear();
        return new Rectangle(name, new Point(x, y), height, width, filled);
    }

    private static Shape CreateSquare()
    {
        Console.WriteLine("Adding square..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y left upper point coordinate:"); 
        var x = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("Enter side:"); 
        var side = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        Console.WriteLine("If you want fill shape, enter[y]"); 
        var filled = IsFilled(Console.ReadLine());

        name ??= "Rectangle";
        Console.Clear();
        return new Square(name, new Point(x, y), side, filled);
    }

    private static Shape CreateLine()
    {
        Console.WriteLine("Adding line..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y first point coordinate:"); 
        var x1 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y1 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("Please, input X and Y second point coordinate:"); 
        var x2 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y2 = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        name ??= "Line";
        Console.Clear();
        return new Line(name, new Point(x1, y1), new Point(x2, y2));
    }

    private static Shape CreateTriangle() //TODO Make Triangle Builder 
    {
        Console.WriteLine("Adding triangle..."); 
        Console.WriteLine("Please, enter name:"); 
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Please, input X and Y upper point coordinate:"); 
        var x = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        var y = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture); 
        
        Console.WriteLine("Enter side:"); 
        var side = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);

        Console.WriteLine("If you want fill shape, enter[y]"); 
        var filled = IsFilled(Console.ReadLine());

        name ??= "Rectangle";
        Console.Clear();
        return new Square(name, new Point(x, y), side, filled);
    }

    private static bool IsFilled(string? command)
    {
        return command != null && command.ToLowerInvariant().Equals("y", StringComparison.Ordinal);
    }
}
