using ConsoleDrawing.Attributes;
using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[CircleValidation(1)]
public class Circle : Shape
{
    public int Radius { get; set; }

    private int Diameter => Radius * 2;
    
    public Point Center { get; set; }

    public override double Perimeter => 2 * Math.PI * Radius;

    public override double SquareShape => Math.PI * Math.Pow(Radius, 2);

    public override Point LeftSideCoordinates => new(Center.CoordX - Radius, Center.CoordY - Radius);
    
    public override Point RightSideCoordinates => new(Center.CoordX + Radius, Center.CoordY + Radius);
    
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
        var circleCoords = new int[Diameter + 1, Diameter + 1]; 
        var startPoint = new Point(Center.CoordX - LeftSideCoordinates.CoordX,
            Center.CoordY - LeftSideCoordinates.CoordY);
        for (var x = 0; x < circleCoords.GetLength(0); x++)
        {
            for (var y = 0; y < circleCoords.GetLength(1); y++)
            {
                //((x1 - start_X) * (x1 - start_X) + (y1 - start_Y) * (y1 - start_Y)) <= r * r
                //Sqrt(Pow(y - y0, 2) + Pow(x - x0, 2) - r <= index) index - for the smooth angels
                if (IsFilled && Math.Sqrt(Math.Pow(y - startPoint.CoordX, 2) + Math.Pow(x - startPoint.CoordY, 2)) 
                    - Radius < 0.5)
                {
                    circleCoords[x, y] = 1;
                }
                else if (Math.Abs(Math.Sqrt(Math.Pow(y - startPoint.CoordX, 2) + Math.Pow(x - startPoint.CoordY, 2)) 
                                  - Radius) < 0.5)
                {
                    circleCoords[x, y] = 1;
                }
            }
        }

        return circleCoords;
    }

    public override string ToString()
    {
        return $"Circle::Name: {ShapeName} || Center: {Center} || Radius: {Radius} || Diameter {Diameter}" +
               $"|| Square: {SquareShape}";
    }
}
