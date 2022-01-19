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
        TryApplySettings();
    }

    /// <summary>
    /// Try apply exists settings,
    /// If an error occurs, the settings will be set to default 
    /// </summary>
    private void TryApplySettings()
    {
        try
        {
            Console.Clear();
            ErrorMessage("Do you want apply settings from the file?"+
                         " Resize window works only on the Windows! If you want enter [y]");
            if (Console.ReadLine()!.ToLowerInvariant().Equals("y", StringComparison.OrdinalIgnoreCase))
                _settingsService.InstallSettingsFromFile();
            else
                _settingsService.InstallDefaultSettings();
        }
        catch (ArgumentOutOfRangeException)
        {
            ErrorMessage("An error occurred while apply the settings, will be set by default. Press enter...");
            _settingsService.InstallDefaultSettings();
            Console.ReadLine();
        }
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
    
    /// <summary>
    /// Added draw state to the stack
    /// </summary>
    private void AddDrawStateToStack()
    {
        States.Push(new DrawState(States, SettingsService.ReadSettingsFile()));
    }

    /// <summary>
    /// Added settings state to the stack
    /// </summary>
    private void AddSettingsStateToStack()
    {
        States.Push(new SettingsState(States, _settingsService));
    }

    public override void Update()
    {
        ShowMenu();
    }
}
