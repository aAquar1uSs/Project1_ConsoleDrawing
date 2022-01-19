using System.Globalization;
using ConsoleDrawing.Services;

namespace ConsoleDrawing.States;

public class MenuState : State
{
    private readonly SettingsService _settingsService;
    
    public MenuState(Stack<State> states) :
        base(states)
    {
        _settingsService = new SettingsService();
        InitSettings();
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
            ConsoleHandler(Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture));
        }
        catch (FormatException)
        {
            ErrorMessage("ERROR::Wrong format!! Press enter...");
            Console.ReadLine();
        }
        catch (OverflowException)
        {
            ErrorMessage("Value was either too large or too small! Press enter...");
            Console.ReadLine();
        }
    }

    private void InitSettings()
    {
        _settingsService.InstallSettingsFromFile();
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
                ErrorMessage("ERROR::Wrong operation, please try again! Press enter...");
                Console.ReadLine();
                break;
        }
    }
    
    private void AddDrawStateToStack()
    {
        States.Push(new DrawState(States, SettingsService.ReadSettingsFile()));
    }

    private void AddSettingsStateToStack()
    {
        States.Push(new SettingsState(States, _settingsService));
    }

    public override void Update()
    {
        ShowMenu();
    }
}
