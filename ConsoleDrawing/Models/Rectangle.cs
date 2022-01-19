using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[Serializable]
public class Rectangle : Shape
{
    public override double Perimeter { get; }
    
    public override double SquareShape { get; }

    public override Point LeftSideCoordinates { get; }
    
    public override Point RightSideCoordinates { get; }

    public Rectangle(string shapeName, bool isFilled) : base(shapeName, isFilled)
    {
        
    }

    public override void Move(DirectionMove dirMove)
    {
        throw new NotImplementedException();
    }

    public override int[,] Render()
    {
        throw new NotImplementedException();
    }
}
