using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public class Rectangle : Shape
{
    public int Height { get; set; }

    public int Width { get; set; }

    public Point LeftUpperPoint { get; set; }

    public override double Perimeter => 2 * Height + 2 * Height;

    public override double SquareShape => Height * Width;

    public override Point LeftSideCoordinates => LeftUpperPoint;

    public override Point RightSideCoordinates => new Point(LeftUpperPoint.CoordX + Width, 
        LeftUpperPoint.CoordY + Height);
    
    public Rectangle(string shapeName, Point leftUpperPoint,
        int height, int width, bool isFilled) : base(shapeName, isFilled)
    {
        Height = height;
        Width = width;
        LeftUpperPoint = leftUpperPoint;
    }

    public override void Move(DirectionMove dirMove)
    {
        LeftUpperPoint.Movement(dirMove);
    }

    public override int[,] Render()
    {
        var picture = new int[Height + 1, Width + 1];
        for (var i = 0; i < picture.GetLength(0); i++)
        { 
            for(var j = 0; j < picture.GetLength(1); j++) 
            {
                    picture[i, j] = 1; 
            }
        }
        
        if (IsFilled)
            return picture;
        
        for (var i = 1; i < picture.GetLength(0) - 1; i++)
        { 
            for (var j = 1; j < picture.GetLength(1) - 1; j++) 
            { 
                picture[i, j] = 0;
            }
        }

        return picture;
    }

    public override string ToString()
    {
        return $"Rectangle::{ShapeName}";
    }
}
