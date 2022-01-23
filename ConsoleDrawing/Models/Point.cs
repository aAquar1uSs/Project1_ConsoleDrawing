using ConsoleDrawing.Attributes;
using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[PointValidation(0, 0)]
public class Point
{
    public int CoordX { get; private set; }
    public int CoordY { get; private set; }
    
    public Point(int coordX, int coordY)
    {
        CoordX = coordX;
        CoordY = coordY;
    }
    
    public void Movement(DirectionMove dirMove)
    {
        switch (dirMove)
        {
            case DirectionMove.Up:
                CoordY--;
                break;
            
            case DirectionMove.Down:
                CoordY++;
                break;
            
            case DirectionMove.Left:
                CoordX--;
                break;
            
            case DirectionMove.Right:
                CoordX++;
                break;
        }
    }

    public override string ToString()
    {
        return $"X: {CoordX}|| Y: {CoordY}";
    }
}
