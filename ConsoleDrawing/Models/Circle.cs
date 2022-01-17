using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[Serializable]
public class Circle : Shape
{
    public int Radius { get; set; }

    public Point Center { get; set; }
    
    public override double Perimeter => 2 * Math.PI * Radius;

    public override double SquareShape => Math.PI * Math.Pow(Radius, 2);
    
    public override Point Coordinates { get; }
    
    public Circle(string shapeName, int radius, Point center, bool isFilled) : base(shapeName, isFilled)
    {
        Radius = radius;
        Center = center;
    }
    
    public override void Move(DirectionMove dirMove)
    {
        Center.Movement(dirMove);
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
