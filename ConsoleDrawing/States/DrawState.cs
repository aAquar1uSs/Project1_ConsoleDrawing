using System.Globalization;
using System.Text.Json;
using ConsoleDrawing.DTO;
using ConsoleDrawing.Enums;
using ConsoleDrawing.Factories;
using ConsoleDrawing.Services;

namespace ConsoleDrawing.States;

public class DrawState : State
{
    private readonly DrawingPicture _drawing;

    private readonly DrawService _drawService;
    
    public DrawState(Stack<State> states, DtoSettings settings) : base(states)
    {
        _drawing = new DrawingPicture(settings.WindowHeight - 10, settings.WindowWidth - 4);
        _drawService = settings.SaveFile != null ? new DrawService(settings.SaveFile) : new DrawService();
    }

    protected override void ShowMenu()
    {
        Console.Clear(); 
        _drawing.Print();
        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Add new shape");
        Console.WriteLine("2 - Change direction in current shape");
        Console.WriteLine("3 - Change current shape");
        Console.WriteLine("4 - Delete figure");
        Console.WriteLine("5 - Upload");
        Console.WriteLine("6 - Save");
        Console.WriteLine("7 - Sort");
        Console.WriteLine("8 - Help");
        Console.WriteLine("0 - Exit");
        
        try
        { 
            ConsoleHandler(Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture));
        }    
        catch (FormatException)
        { 
            ErrorMessage("ERROR::Invalid arguments!! Press enter...");
            Console.ReadLine();
        }
        catch (OverflowException)
        {
            ErrorMessage("Value was either too large or too small! Press enter...");
            Console.ReadLine();
        }
    }

    protected override void ConsoleHandler(int selection)
    {
        switch (selection)
        {
            case 1:
                InvokeShapesMenu();
                break;
            case 2:
                ChangeDirection();
                break;
            case 3:
                TryChangeCurrentShape();
                break;
            case 4:
                DeleteShape();
                break;
            case 5:
                Upload();
                break;
            case 6:
                SaveToFile();
                break;
            case 7:
                InvokeSortOperation();
                break;
            case 8:
                HelpMenu();
                break;
            case 0:
                DeleteState();
                break;
            default:
                ErrorMessage("ERROR::Wrong operation, please try again! Press enter...");
                Console.ReadLine();
                break;
        }
    }

    private void InvokeShapesMenu()
    {
        Console.WriteLine("-------------");
        Console.WriteLine("1 - Add line");
        Console.WriteLine("2 - Add circle");
        Console.WriteLine("3 - Add triangle");
        Console.WriteLine("4 - Add rectangle");
        Console.WriteLine("5 - Add square");
        Console.WriteLine("0 - Exit");
        
        AddShapeToPicture();

        Console.Clear();
    }
    
    private void AddShapeToPicture()
    {
        var choice = Convert.ToInt32(Console.ReadLine(),
            CultureInfo.CurrentCulture);
        if (choice == 0)
            return;
        
        var shape = ShapeFactory.ResolveShapes(choice);
        if (shape is null)
            throw new FormatException(nameof(shape));
        
        if (!_drawing.AddShapeToList(shape))
        {
            ErrorMessage("The shape went beyond the canvas. Please try again!");
            Console.ReadLine();
        } 
    }

    private static void HelpMenu()
    {
        Console.WriteLine("========Help=======");
        Console.WriteLine("ArrowUp - go up");
        Console.WriteLine("ArrowDown - go down");
        Console.WriteLine("ArrowLeft - go left");
        Console.WriteLine("ArrowRight - go right");
        Console.WriteLine("PageUp - select upper shape");
        Console.WriteLine("PageDown - select lower shape");
        Console.WriteLine("Press enter...");
        Console.ReadLine();
    }

    private void ChangeDirection()
    {
        var keyInfo = Console.ReadKey();
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    _drawing.ChangeShapeDirection(DirectionMove.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    _drawing.ChangeShapeDirection(DirectionMove.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    _drawing.ChangeShapeDirection(DirectionMove.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Console.Clear();
                    _drawing.ChangeShapeDirection(DirectionMove.Right);
                    break;
            }
            keyInfo = Console.ReadKey();
        }
    }

    private void DeleteShape()
    {
        Console.WriteLine("Enter shape name which you want delete...");
        foreach (var s in _drawing.GetShapeList())
        {
            Console.WriteLine($"{s}");
        }

        var command = Console.ReadLine();
        if (command is null)
            return;
        _drawing.DeleteShapeFromList(command);
    }

    private void InvokeSortOperation()
    {
        var perimeter = false;
        var square = false;
        Console.WriteLine("------------------------");
        Console.WriteLine("1 ---- Sort by Perimeter");
        Console.WriteLine("2 ---- Sort by Square");
        
        if(!int.TryParse(Console.ReadLine(), out var selection))
            throw new FormatException();
        if (selection == 1)
            perimeter = true;
        else
            square = true;
        
        Console.WriteLine("Please, choose mode:");
        Console.WriteLine("1 --- in descending order");
        Console.WriteLine("2 --- in ascending order");

        if (!int.TryParse(Console.ReadLine(), out var mode))
            throw new FormatException();
        
        if (!_drawing.Sort(mode, square, perimeter))
            ErrorMessage("ERROR::Invalid arguments!! Press enter...");
    }

    private void TryChangeCurrentShape()
    {
        Console.WriteLine("PageUp - select upper shape");
        Console.WriteLine("PageDown - select lower shape");
        var keyInfo = Console.ReadKey();
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.PageUp:
                    _drawing.SelectUpperShape();
                    break;
                case ConsoleKey.PageDown:
                    _drawing.SelectLowerShape();
                    break;
            }
            keyInfo = Console.ReadKey();
        }
    }
    
    private void SaveToFile()
    {
        try
        {
            _drawService.SavePictureToFile(_drawing.GetShapeList());
            Console.WriteLine("Your painting has been successfully installed!!! Press enter...");
            Console.ReadLine();
        }
        catch (NotSupportedException)
        {
            ErrorMessage("Error occured when file had been saved. Press enter");
            Console.ReadLine();
        }
    }

    private void Upload()
    {
        try
        {
            var list = _drawService.UploadFromFile();
            if (list is null)
                return;
            _drawing.SetShapeList(list);
        }
        catch (JsonException)
        {
            ErrorMessage("Error occured when file had been uploaded. Press enter");
            Console.ReadLine();
        }
        catch (NotSupportedException)
        {
            ErrorMessage("Error occured when file had been uploaded. Press enter");
            Console.ReadLine();
        }
    }
    
    public override void Update()
    {
        ShowMenu();
    }
}
