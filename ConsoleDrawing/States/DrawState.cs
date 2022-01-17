using System.Globalization;
using ConsoleDrawing.Models;

namespace ConsoleDrawing.States;

public class DrawState : State
{
    private List<Shape> _shapes;

    public DrawState(Stack<State> states) : base(states)
    {
        _shapes = new List<Shape>();
    }

    protected override void ShowMenu()
    {
       Console.Clear();
       Console.WriteLine("Menu:");
       Console.WriteLine("1 - Add new figure");
       Console.WriteLine("2 - Upload");
       Console.WriteLine("3 - Save");
       Console.WriteLine("4 - Sort");
       Console.WriteLine("0 - Exit");

       try
       {
            ConsoleHandler(ConvertConsoleInputToInt());
       }
       catch (FormatException)
       {
           Console.WriteLine("ERROR::Wrong format!!");
           Console.WriteLine("Press enter...");
           Console.ReadLine();
       }
    }

    protected override void ConsoleHandler(int selection)
    {
        switch (selection)
        {
            case 1:
                InvokeFiguresMenu();
                break;
            case 2:
                //Upload();
                break;
            case 3:
                //Save();
                break;
            case 4:
                //Sort();
                break;
            case 5:
                DeleteState();
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
                
        }
    }

    private static void InvokeFiguresMenu()
    {
        Console.Clear();
        Console.WriteLine("1 - Line");
        Console.WriteLine("2 - Circle");
        Console.WriteLine("3 - Triangle");
        Console.WriteLine("4 - Rectangle");
        Console.WriteLine("5 - Square");
        Console.ReadLine();
    }
    
    public override void Update()
    {
        ShowMenu();
    }
}
