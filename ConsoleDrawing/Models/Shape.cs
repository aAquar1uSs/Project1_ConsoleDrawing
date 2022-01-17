using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public abstract class Shape
{
    public string ShapeName { get; set; }

    public abstract double Perimeter { get; }

    public abstract double SquareShape { get; }

    public abstract Point Coordinates { get; }

    public bool IsFilled { get; set; }

    public abstract void Move(DirectionMove dirMove);
    
    protected Shape(string shapeName, bool isFilled)
    {
        ShapeName = shapeName;
        this.IsFilled = isFilled;
    }

}
