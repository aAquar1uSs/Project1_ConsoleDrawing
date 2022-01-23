using ConsoleDrawing.Enums;
using ConsoleDrawing.Models;

namespace ConsoleDrawing;

public class DrawingPicture
{
    private static readonly char[] _levels = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D',
        'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    private List<Shape> _shapes = new();

    private char[,] Canvas { get; }
    
    private int CanvasHeight { get; }
    
    private int CanvasWidth { get; }

    private int Current { get; set; }

    private Shape CurrentShape => (_shapes.Count == 0 ? null : _shapes[Current])!;

    public DrawingPicture(int canvasHeight = 50, int canvasWidth = 120)
    {
        CanvasHeight = canvasHeight;
        CanvasWidth = canvasWidth;
        Canvas = new char[CanvasHeight + 2, CanvasWidth + 2];
    }
    
    public List<Shape> GetShapeList()
    {
        return _shapes;
    }

    public void SetShapeList(List<Shape> shapes)
    {
        _shapes = shapes;
    }

    private void BuildCanvas()
    {
        for(var i = 0; i < Canvas.GetLength(0); i++)
        {
            for(var j = 0; j < Canvas.GetLength(1); j++)
            {
                Canvas[i, j] = ' ';
            }
        }
        for (var i = 0; i < Canvas.GetLength(0); i++)
        {
            Canvas[i, 0] = '|';
            Canvas[i, Canvas.GetLength(1)-1] = '|';
        }
        for (var i = 0; i < Canvas.GetLength(1); i++)
        {
            Canvas[0, i] = '|';
            Canvas[Canvas.GetLength(0) - 1, i] = '|';
        }
    }

    public void ChangeShapeDirection(DirectionMove dir)
    {
        Console.Clear();
        if(CheckCollision(dir))
            CurrentShape.Move(dir);
        Print(); 
    }

    private bool CheckCollision(DirectionMove dir)
    {
        return dir switch
        {
            DirectionMove.Up => CurrentShape.LeftSideCoordinates.CoordY != 1,
            DirectionMove.Down => CurrentShape.RightSideCoordinates.CoordY <= CanvasHeight - 1,
            DirectionMove.Left => CurrentShape.LeftSideCoordinates.CoordX != 1,
            DirectionMove.Right => CurrentShape.RightSideCoordinates.CoordX <= CanvasWidth - 1,
            _ => false
        };
    }
    
    public bool AddShapeToList(Shape shape)
    {
        if (shape.LeftSideCoordinates.CoordX >= CanvasWidth ||
            shape.LeftSideCoordinates.CoordY >= CanvasHeight ||
            shape.RightSideCoordinates.CoordX >= CanvasWidth ||
            shape.RightSideCoordinates.CoordY >= CanvasHeight)
        {
            return false;
        }
        _shapes.Add(shape);
        return true;
    }

    public void DeleteShapeFromList(string name)
    {
        var shape = _shapes.Select(x => x)
            .Where(x => x.ShapeName.Equals(name, StringComparison.Ordinal))
            .ToList();
        _shapes = _shapes.Except(shape).ToList();
        Current--;
    }

    public bool Sort(int mode, bool bySquare, bool byPerimeter)
    {
        switch (byPerimeter)
        {
            case true when mode == 1:
                _shapes = _shapes.OrderByDescending(x => x.Perimeter).ToList();
                return true;
            case true when mode == 2:
                _shapes = _shapes.OrderBy(x => x.Perimeter).ToList();
                return true;
            default:
                switch (bySquare)
                {
                    case true when mode == 1:
                        _shapes = _shapes.OrderByDescending(x => x.SquareShape).ToList();
                        return true;
                    case true when mode == 2:
                        _shapes = _shapes.OrderBy(x => x.SquareShape).ToList();
                        return true;
                    default:
                        return false;
                }
        }
    }

    public void SelectUpperShape()
    {
        if (Current == _shapes.Count - 1)
            return;
        Current++;
        Console.WriteLine($"Current shape: {_shapes[Current]}");
    }

    public void SelectLowerShape()
    { 
        if (Current == 0)
            return;
        Current--;
        Console.WriteLine($"Current shape: {_shapes[Current]}");
    }

    private char[,] ToPicture()
    {
        BuildCanvas();
        for(var i = 0; i < _shapes.Count; i++)
        {
            var shapeMatrix = _shapes[i].Render();
            for (var x = 0; x < shapeMatrix.GetLength(0); x++)
            {
                for (var y = 0; y < shapeMatrix.GetLength(1); y++)
                {
                    if (shapeMatrix[x, y] == 1)
                    {
                        Canvas[x + _shapes[i].LeftSideCoordinates.CoordY, 
                            y + _shapes[i].LeftSideCoordinates.CoordX] = _levels[i];
                    }
                }
            }
        }
        return Canvas;
    }
    
    public void Print()
    {
        var picture = ToPicture();
        for (var i = 0; i < picture.GetLength(0); i++)
        {
            for (var j = 0; j < picture.GetLength(1); j++)
            {
                Console.Write(picture[i, j]);
            }
            Console.WriteLine();
        }
    }
}
