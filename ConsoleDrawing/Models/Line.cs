using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public class Line : Shape
{
    public Point CoordX1Y1 { get; set; }
    
    public Point CoordX2Y2 { get; set; }

    public override double Perimeter => Math.Sqrt(Math.Pow(CoordX2Y2.CoordX - CoordX1Y1.CoordX, 2) +
                                                  Math.Pow(CoordX2Y2.CoordY - CoordX1Y1.CoordY, 2));
    //AB = Sqrt(Pow(x2 - x1, 2) + Pow(y2 - y1, 2))
    public double LineHeight => Perimeter;
    
    public override double SquareShape => 0;

    public override Point LeftSideCoordinates => new(Math.Min(CoordX1Y1.CoordX, CoordX2Y2.CoordX),
        Math.Min(CoordX1Y1.CoordY, CoordX2Y2.CoordY));

    public override Point RightSideCoordinates => new(Math.Max(CoordX1Y1.CoordX, CoordX2Y2.CoordX),
    Math.Max(CoordX1Y1.CoordY, CoordX2Y2.CoordY));
    
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
        var dX = Math.Abs(CoordX1Y1.CoordY - CoordX2Y2.CoordY) + 1;
        var dY = Math.Abs(CoordX1Y1.CoordX - CoordX2Y2.CoordX) + 1;
        
        var linePicture = new int[dX, dY];
        
        FillArrayEmptyValues(ref linePicture);
        
        var point1 = new Point(CoordX1Y1.CoordX - LeftSideCoordinates.CoordX, CoordX1Y1.CoordY 
                                                                          - LeftSideCoordinates.CoordY);
        var point2 = new Point(CoordX2Y2.CoordX - LeftSideCoordinates.CoordX, CoordX2Y2.CoordY
                                                                              - LeftSideCoordinates.CoordY);
        //Bresenham's line algorithm
        // y = (y1 - y0 / x1 - x0) * (x - x0) + y0 
        int x;
        if (dX >= dY)
        {
            for (var i = 0; i < linePicture.GetLength(0); i++)
            {
                if (point1.CoordY == point2.CoordY)
                    x = 0;
                else
                    x = (int)Math.Round((double)(i - point1.CoordY) / (point2.CoordY - point1.CoordY) * 
                        (point2.CoordX - point1.CoordX) + point1.CoordX);
                linePicture[i, x] = 1;
            }
        }
        else 
        {
            for (var i = 0; i < linePicture.GetLength(1); i++)
            {
                if (point1.CoordX == point2.CoordX)
                    x = 0;
                else
                    x = (int)Math.Round((double)(i - point1.CoordX) / (point2.CoordX - point1.CoordX) * 
                        (point2.CoordY - point1.CoordY) + point1.CoordY);
                linePicture[x, i] = 1;
            }
        }
        return linePicture;
    }

    private static void FillArrayEmptyValues(ref int[,] array)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = 0;
            }
        }
    }

    public override string ToString()
    {
        return $"Line::Name: {ShapeName} || Point1: {CoordX1Y1} || Point2: {CoordX2Y2}";
    }
}
