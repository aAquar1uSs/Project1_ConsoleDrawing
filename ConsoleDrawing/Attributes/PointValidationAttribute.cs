using System.ComponentModel.DataAnnotations;
using ConsoleDrawing.Models;

namespace ConsoleDrawing.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class PointValidationAttribute : ValidationAttribute
{
    private int MinX { get; set; }

    private int MinY { get; set; }

    public PointValidationAttribute(int minX, int minY)
    {
        MinX = minX;
        MinY = minY;
    }

    public override bool IsValid(object? value)
    {
        return value is Point p &&
               p.CoordX >= MinX &&
               p.CoordY >= MinY;
    }
}
