using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public class Triangle : Shape
{
    public Point CoordsX1Y1 { get; set; }

    public Point CoordsX2Y2 { get; set; }

    public Point CoordsX3Y3 { get; set; }

    public List<Line> Sides => new() 
    {
        new Line("A", CoordsX1Y1, CoordsX2Y2),
        new Line("B", CoordsX1Y1, CoordsX3Y3),
        new Line("C", CoordsX3Y3, CoordsX2Y2)
    };

    public override double Perimeter => Sides.Select(x => x.Perimeter).Sum();

    //Sqrt(p(p-a)(p-b)(p-c)) p = (a + b + c) / 2
    public override double SquareShape => Math.Sqrt(Perimeter / 2 *
                                                    (Perimeter / 2 - Sides[0].LineHeight) *
                                                    (Perimeter / 2 - Sides[1].LineHeight) *
                                                    (Perimeter / 2 - Sides[2].LineHeight));
    public override Point LeftSideCoordinates =>
        new(new[] {CoordsX1Y1.CoordX, CoordsX2Y2.CoordX, CoordsX3Y3.CoordX}.Min(),
            new[] {CoordsX1Y1.CoordY, CoordsX2Y2.CoordY, CoordsX3Y3.CoordY}.Min());

    public override Point RightSideCoordinates =>
        new(new[] {CoordsX1Y1.CoordX, CoordsX2Y2.CoordX, CoordsX3Y3.CoordX}.Max(),
            new[] {CoordsX1Y1.CoordY, CoordsX2Y2.CoordY, CoordsX3Y3.CoordY}.Max());
    
    public Triangle(string shapeName,Point coordsX1Y1, Point coordsX2Y2, Point coordsX3Y3,  bool isFilled)
        : base(shapeName, isFilled)
    {
        CoordsX1Y1 = coordsX1Y1;
        CoordsX2Y2 = coordsX2Y2;
        CoordsX3Y3 = coordsX3Y3;
    }
    
    public override void Move(DirectionMove dirMove)
    {
        CoordsX1Y1.Movement(dirMove);
        CoordsX2Y2.Movement(dirMove);
        CoordsX3Y3.Movement(dirMove);
    }

    public override int[,] Render()
    {
        return !IsFilled ? DrawLinesTriangle() : FillTriangle();
    }

    private int[,] DrawLinesTriangle()
    {
        var trianglePicture = new int[RightSideCoordinates.CoordY - LeftSideCoordinates.CoordY + 1,
            RightSideCoordinates.CoordX - LeftSideCoordinates.CoordX + 1];

        FillArrayEmptyValues(ref trianglePicture);

        foreach (var line in Sides)
        {
            var dX = line.LeftSideCoordinates.CoordX - LeftSideCoordinates.CoordX;
            var dY = line.LeftSideCoordinates.CoordY - LeftSideCoordinates.CoordY;
            var linePicture = line.Render();
            for (var i = 0; i < linePicture.GetLength(0); i++)
            {
                for (var j = 0; j < linePicture.GetLength(1); j++)
                {
                    if (linePicture[i, j] == 1)
                    {
                        trianglePicture[i + dY, j + dX] = 1;
                    }
                }
            }
        }

        return trianglePicture;
    }

    private int[,] FillTriangle()
    {
        var trianglePicture = DrawLinesTriangle();
        for (var x = 0; x < trianglePicture.GetLength(0); x++)
        {
            var indexStart = 0;
            var indexEnd = 0;
            for (var y = 0; y < trianglePicture.GetLength(1); y++)
            {
                if (trianglePicture[x, y] != 1) continue;
                if (indexStart == 0)
                    indexStart = y;
                indexEnd = y;
            }
            for (var y = indexStart; y <= indexEnd; y++)
            { 
                trianglePicture[x, y] = 1; 
            }
        }
        
        return trianglePicture;
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
        return $"Triangle::Name: {ShapeName} || Point1: {CoordsX1Y1} || Point2: {CoordsX2Y2} || Point3 {CoordsX3Y3}" +
               $"|| Square: {SquareShape}";
    }
}
