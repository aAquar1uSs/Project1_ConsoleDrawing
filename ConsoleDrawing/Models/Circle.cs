using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[Serializable]
public class Circle : Shape
{
    public override double Perimeter => 0;
    
    public override double SquareShape { get; }
    
    public override Point Coordinates { get; }
    
    public Circle(string shapeName, bool isFilled) : base(shapeName, isFilled)
    {
        
    }
    
    public override void Move(DirectionMove dirMove)
    {
        throw new NotImplementedException();
    }
}
