using System.ComponentModel.DataAnnotations;
using ConsoleDrawing.Models;

namespace ConsoleDrawing.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class RectangleValidationAttribute : ValidationAttribute
{
    private int MinHeight { get; set; }

    private int MinWidth { get; set; }

    public RectangleValidationAttribute(int minHeight, int minWidth)
    {
        MinHeight = minHeight;
        MinWidth = minWidth;
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            Square square => square.Height >= MinHeight,
            Rectangle rectangle => rectangle.Height >= MinHeight && rectangle.Width >= MinWidth,
            _ => false
        };
    }
}
