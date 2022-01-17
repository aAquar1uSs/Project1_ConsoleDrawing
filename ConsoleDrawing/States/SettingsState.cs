using System.Globalization;
using ConsoleDrawing.Services;

namespace ConsoleDrawing.States;

public class SettingsState : State
{
    private readonly SettingsService _settingsService;

    public SettingsState(Stack<State> states) : base(states)
    {
        _settingsService = new SettingsService();
        _settingsService.InstallSettingsFromFile();
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
            ConsoleHandler(ConvertConsoleInputToInt());
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
                Console.Clear();
                Console.WriteLine("Careful! This function only works on Windows! You sure? yes[y] or no[n]");
                if (Console.ReadLine()!.ToLowerInvariant().Equals("y", StringComparison.Ordinal))
                    try
                    {
                        _settingsService.InvokeResizeOperation();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("ERROR::The new console window size would force the console buffer " +
                                          "size to be too large.");
                        Console.WriteLine("Press enter...");
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ERROR::Wrong format!!");
                        Console.WriteLine("Press enter...");
                        Console.ReadLine();
                    }
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
        }
    }

    public override void Update()
    {
        ShowMenu();
    }
}
