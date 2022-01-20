using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public class Point
{
    public int CoordX { get; set; }
    public int CoordY { get; set; }
    
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
}
