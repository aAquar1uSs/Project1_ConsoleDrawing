using System.ComponentModel.DataAnnotations;
using ConsoleDrawing.Models;

namespace ConsoleDrawing.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CircleValidationAttribute : ValidationAttribute
{
    private int MinRadius { get; set; }
    
    public CircleValidationAttribute(int minRadius)
    {
        MinRadius = minRadius;
    }

    public override bool IsValid(object? value)
    {
        return value is Circle circle &&
               circle.Radius >= MinRadius;
    }
}
