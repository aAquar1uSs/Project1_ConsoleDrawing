using System.Globalization;
using ConsoleDrawing.Services;

namespace ConsoleDrawing.States;

public class SettingsState : State
{
    private readonly SettingsService _settingsService;

    public SettingsState(Stack<State> states, SettingsService service) : base(states)
    {
        _settingsService = service;
    }
    
    protected override void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("============Settings============");
        Console.WriteLine("1-------Resize the window-------");
        Console.WriteLine("2------Select File to Save------");
        Console.WriteLine("3--------Show all settings------");
        Console.WriteLine("0-------------Exit--------------");

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
        catch (ArgumentOutOfRangeException)
        {
            ErrorMessage("ERROR::The new console window size would force the console buffer " +
                  "size to be too large. Press enter...");
            Console.ReadLine();
        }
        catch (ArgumentNullException)
        {
            ErrorMessage("ERROR::Сould not read file, please try again! Press enter...");
            Console.ReadLine();
        }
    }

    protected override void ConsoleHandler(int selection)
    {
        switch (selection)
        {
            case 1:
                Console.Clear();
                ErrorMessage("Careful! This function works only on Windows! You sure? yes[y] or no[n]");
                if (Console.ReadLine()!.ToLowerInvariant().Equals("y", StringComparison.OrdinalIgnoreCase)) 
                    _settingsService.InvokeResizeOperation();
                break;
            case 2:
                _settingsService.SetFileForSave();
                break;
            case 3:
                _settingsService.ShowSettings();
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

    public override void Update()
    {
        ShowMenu();
    }
}
