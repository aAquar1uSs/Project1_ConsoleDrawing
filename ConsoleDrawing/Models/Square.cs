using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[Serializable]
public class Square : Shape
{
    public override double Perimeter { get; }

    public override double SquareShape => 0;
    
    public override Point Coordinates { get; }
    
    public Square(string shapeName, bool isFilled) : base(shapeName, isFilled)
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
