using System.Reflection;
using ConsoleDrawing.Attributes;
using ConsoleDrawing.Models;

namespace ConsoleDrawing.Tools;

public static class ShapesValidator
{
    public static bool ValidateCircle(Shape circle)
    {
        var type = typeof(Circle);
        var attr = type.GetCustomAttribute<CircleValidationAttribute>();
        return attr is not null && attr.IsValid(circle);
    }
    
    public static bool PointValidate(Point p)
    {
        var type = typeof(Point);
        var attr = type.GetCustomAttribute<PointValidationAttribute>();
        return attr is not null && attr.IsValid(p);
    }
    
    public static bool ValidateRectangle(Shape rect)
    {
        var type = typeof(Rectangle);
        var attr = type.GetCustomAttribute<RectangleValidationAttribute>();
        return attr is not null && attr.IsValid(rect);
    }
}
