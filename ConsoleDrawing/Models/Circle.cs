using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public class Circle : Shape
{
    public int Radius { get; set; }

    public Point Center { get; set; }

    public override double Perimeter => 2 * Math.PI * Radius;

    public override double SquareShape => Math.PI * Math.Pow(Radius, 2);

    public override Point LeftSideCoordinates => new Point(Center.CoordX - Radius, Center.CoordY - Radius);
    
    public override Point RightSideCoordinates => new Point(Center.CoordX + Radius, Center.CoordY + Radius);
    
    public Circle(string shapeName, Point center, int radius, bool isFilled) : base(shapeName, isFilled)
    {
        Radius = radius;
        Center = center;
    }

    public override void Move(DirectionMove dirMove)
    {
        Center.Movement(dirMove);
    }

    public override int[,] Render()
    {
        var circleCoords = new int[Radius * 2 + 1, Radius * 2 + 1];
        var center = new Point(Center.CoordX - LeftSideCoordinates.CoordX, Center.CoordY - LeftSideCoordinates.CoordY);
        for (var i = 0; i < circleCoords.GetLength(0); i++)
        {
            for (var j = 0; j < circleCoords.GetLength(1); j++)
            {
                circleCoords[i, j] = 0;

                if (IsFilled && Math.Sqrt(Math.Pow(j - center.CoordY, 2) + Math.Pow(i - center.CoordY, 2)) 
                    - Radius < 0.5)
                {
                    circleCoords[i, j] = 1;
                }
                else if ((Math.Abs(Math.Sqrt(Math.Pow(j - center.CoordX, 2) + Math.Pow(i - center.CoordX, 2)) 
                                   - Radius) < 0.5))
                {
                    circleCoords[i, j] = 1;
                }
            }
        }

        return circleCoords;
    }

    public override string ToString()
    {
        return $"Circle::Name: {ShapeName}";
    }
}
