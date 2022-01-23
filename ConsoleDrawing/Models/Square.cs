

using ConsoleDrawing.Attributes;

namespace ConsoleDrawing.Models;

[RectangleValidation(0, 0)]
public class Square : Rectangle
{
    public Square(string shapeName, Point leftUpperPoint, int side, bool isFilled) 
        : base(shapeName, leftUpperPoint, side, side, isFilled)
    {
        
    }

    public override string ToString()
    {
        return $"Square::Name: ${ShapeName} || Side: {Height} || Square: {SquareShape}";
    }
}
