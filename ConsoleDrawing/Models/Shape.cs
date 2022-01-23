using ConsoleDrawing.Enums;

namespace ConsoleDrawing.Models;

public abstract class Shape
{
    public string ShapeName { get; set; }

    public abstract double Perimeter { get; }

    public abstract double SquareShape { get; }

    /// <summary>
    /// Coordinates which exist in left side.
    /// </summary>
    public abstract Point LeftSideCoordinates { get; }
    
    /// <summary>
    /// Coordinates which exist in right side.
    /// </summary>
    public abstract Point RightSideCoordinates { get; }

    public bool IsFilled { get; set; }
    
    public Shape(string shapeName, bool isFilled)
    {
        ShapeName = shapeName;
        this.IsFilled = isFilled;
    }

    public abstract void Move(DirectionMove dirMove);
    
    /// <summary>
    /// Draw shape in matrix.
    /// </summary>
    /// <returns>int[,]</returns>
    public abstract int[,] Render();


}
