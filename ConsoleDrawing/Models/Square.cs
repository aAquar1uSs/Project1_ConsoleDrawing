

namespace ConsoleDrawing.Models;

public class Square : Rectangle
{
    public Square(string shapeName, Point leftUpperPoint, int side, bool isFilled) 
        : base(shapeName, leftUpperPoint, side, side, isFilled)
    {
        
    }
}
