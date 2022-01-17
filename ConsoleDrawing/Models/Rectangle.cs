using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[Serializable]
public class Rectangle : Shape
{
    public override double Perimeter { get; }
    
    public override double SquareShape { get; }

    public override Point Coordinates { get; }
    
    public Rectangle(string shapeName, bool isFilled) : base(shapeName, isFilled)
    {
        
    }

    public override void Move(DirectionMove dirMove)
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }

    public override void Render()
    {
        throw new NotImplementedException();
    }
}
