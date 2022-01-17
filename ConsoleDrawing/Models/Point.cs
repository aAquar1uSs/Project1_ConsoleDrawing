using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

[Serializable]
public class Point
{
    public int CoordX { get; set; }
    public int CoordY { get; set; }

    public Point(int x, int y)
    {
        CoordX = x;
        CoordY = y;
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
            default:
               break;
        }
    }
}
