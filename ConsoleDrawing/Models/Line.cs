using System.Text.Json.Serialization;
using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public class Line : Shape
{
    public Point CoordX1Y1 { get; set; }
    
    public Point CoordX2Y2 { get; set; }

    public override double Perimeter => 0;

    public override double SquareShape => 0;
    
    public override Point LeftSideCoordinates { get; }

    public override Point RightSideCoordinates { get; }
    
    [JsonConstructor]
    public Line(string shapeName, Point coordX1Y1, Point coordX2Y2) : base(shapeName, false)
    {
        CoordX1Y1 = coordX1Y1;
        CoordX2Y2 = coordX2Y2;
    }

    
    public override void Move(DirectionMove dirMove)
    {
        CoordX1Y1.Movement(dirMove);
        CoordX2Y2.Movement(dirMove);
    }
    
    public override int[,] Render()
    {
        throw new NotImplementedException();
    }
}
