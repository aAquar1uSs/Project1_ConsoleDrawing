using System.Globalization;

namespace ConsoleDrawing.States;

public class MenuState : State
{
    public MenuState(ref Stack<State> states) :
        base(states)
    {
        
    }
        
    protected override void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("==========================Menu==========================");
        Console.WriteLine("1---------Draw---------");
        Console.WriteLine("2-------Settings-------");
        Console.WriteLine("0---------Exit---------");

        try
        {
            ConsoleHandler(Convert.ToInt32(Console.ReadLine(),CultureInfo.CurrentCulture));
        }
        catch (FormatException)
        {
            Console.Clear();
            ShowMenu();
        }
    }

    protected override void ConsoleHandler(int selection)
    {
        switch (selection)
        {
            case 1:
                AddDrawStateToStack();
                break;
            case 2:
                AddSettingsStateToStack();
                break;
            case 0:
                DeleteState();
                break;
            default:
                Console.WriteLine("Wrong operation, please try again!");
                break;
        }
    }
    
    private void AddDrawStateToStack()
    {
        States.Push(new DrawState(States));
    }

    private void AddSettingsStateToStack()
    {
        States.Push(new SettingsState(States));
    }

    public override void Update()
    {
        ShowMenu();
    }
}
