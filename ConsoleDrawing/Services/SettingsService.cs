using System.Globalization;
using System.Text.Json;
using ConsoleDrawing.DTO;

namespace ConsoleDrawing.Services;

public sealed class SettingsService
{
    private DtoSettings _dtoSettings = new();
    private const string SettingsFile = "settings.json";
    
    public static DtoSettings ReadSettingsFile()
    {
        var settings = DeserializeJson(File.OpenRead(SettingsFile));
        return settings ?? new DtoSettings();
    }
    
    public void InstallSettingsFromFile()
    {
        if (!SettingFileIsExit())
        {
            _dtoSettings = new DtoSettings();
            WriteToSettingsFile(_dtoSettings);
        }
        else
        {
            _dtoSettings = ReadSettingsFile();
        }
        
        ResizeWindow();
    }
    
    private static DtoSettings? DeserializeJson(Stream stream)
    {
        using var streamReader = new StreamReader(stream);
        var json = streamReader.ReadToEnd();
        return JsonSerializer.Deserialize<DtoSettings>(json);
    }

    public static bool SettingFileIsExit()
    {
        return File.Exists(SettingsFile);
    }

    public static void WriteToSettingsFile(DtoSettings? settings)
    {
        settings = settings ?? throw new ArgumentNullException(nameof(settings));
        
        var json = JsonSerializer.Serialize(settings);
        using var streamWriter = new StreamWriter(SettingsFile);
        streamWriter.WriteLine(json);
    }
    
    public void InvokeResizeOperation()
    {
        Console.WriteLine("Max height: " + Console.LargestWindowHeight);
        Console.WriteLine("Max width: " + Console.LargestWindowWidth);
        Console.WriteLine("Please, enter a value for the window height: ");
        _dtoSettings.WindowHeight = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
        Console.WriteLine("Please, enter a value for the window width: ");
        _dtoSettings.WindowWidth = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
        ResizeWindow();
        WriteToSettingsFile(_dtoSettings);
    }
    
    private void ResizeWindow()
    {
#pragma warning disable CA1416
        Console.SetWindowSize(_dtoSettings.WindowWidth, _dtoSettings.WindowHeight);
#pragma warning restore CA1416
    }
    
    public void ShowSettings()
    {
        Console.Clear();
        Console.WriteLine(_dtoSettings);
        Console.WriteLine("Please, press enter...");
        Console.ReadLine();
    }
    
    public void SetFileForSave()
    {
        Console.WriteLine("Please, enter a filename...");
        _dtoSettings.SaveFile = Console.ReadLine();
        WriteToSettingsFile(_dtoSettings);
    }
}
