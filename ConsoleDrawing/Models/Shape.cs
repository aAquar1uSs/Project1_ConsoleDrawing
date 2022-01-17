using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public abstract class Shape
{
    public string ShapeName { get; set; }

    public abstract double Perimeter { get; }

    public abstract double SquareShape { get; }

    public abstract Point Coordinates { get; }

    public bool IsFilled { get; set; }
    
    protected Shape(string shapeName, bool isFilled)
    {
        ShapeName = shapeName;
        this.IsFilled = isFilled;
    }
    
    public abstract void Move(DirectionMove dirMove);

    public abstract void Update();

    public abstract void Render();


}
