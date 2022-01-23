using ConsoleDrawing.Attributes;
using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[RectangleValidation(0, 0)]
public class Rectangle : Shape
{
    public int Height { get; set; }

    public int Width { get; set; }

    public Point LeftUpperPoint { get; set; }

    public override double Perimeter => 2 * Height + 2 * Height;

    public override double SquareShape => Height * Width;

    public override Point LeftSideCoordinates => LeftUpperPoint;

    public override Point RightSideCoordinates => new(LeftUpperPoint.CoordX + Width, 
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
        return IsFilled ? FillRectangle() : DrawLinesRectangle();
    }

    private int[,] FillRectangle()
    {
        var rectPicture = new int[Height + 1, Width + 1];
        for (var i = 0; i < rectPicture.GetLength(0); i++)
        { 
            for(var j = 0; j < rectPicture.GetLength(1); j++) 
            {
                rectPicture[i, j] = 1; 
            }
        }
        return rectPicture;
    }

    private int[,] DrawLinesRectangle()
    {
        var rectPicture = FillRectangle();
        for (var i = 1; i < rectPicture.GetLength(0) - 1; i++)
        { 
            for (var j = 1; j < rectPicture.GetLength(1) - 1; j++) 
            { 
                rectPicture[i, j] = 0;
            }
        }
        return rectPicture;
    } 

    public override string ToString()
    {
        return $"Rectangle::Name: {ShapeName} || Height: {Height} || Width: {Width} || Square: {SquareShape}";
    }
}
