using System.Globalization;
using System.Text.Json;
using ConsoleDrawing.DTO;

namespace ConsoleDrawing.Services;

public sealed class SettingsService
{
    private DtoSettings? _dtoSettings = new();
    private const string SettingsFile = "settings.json";
    
    public DtoSettings? ReadSettingsFile()
    {
        return DeserializeJson(File.OpenRead(SettingsFile));
    }
    
    public void InstallSettingsFromFile()
    {
        if (!SettingFileIsExit())
        {
            _dtoSettings = new DtoSettings()
            {
                WindowHeight = Console.WindowHeight,
                WindowWidth = Console.WindowWidth,
                SaveFile = "default.json"
            };
            WriteToSettingsFile(_dtoSettings);
        }
        else
        {
            _dtoSettings = ReadSettingsFile();
        }
    }
    
    private DtoSettings? DeserializeJson(Stream stream)
    {
        using var streamReader = new StreamReader(stream);
        var json = streamReader.ReadToEnd();
        return _dtoSettings = JsonSerializer.Deserialize<DtoSettings>(json);
    }

    public bool SettingFileIsExit()
    {
        return File.Exists(SettingsFile);
    }

    public void WriteToSettingsFile(DtoSettings? settings)
    {
        var json = JsonSerializer.Serialize(settings);
        using var streamWriter = new StreamWriter(SettingsFile);
        streamWriter.WriteLine(json);
    }
    
    public void InvokeResizeOperation()
    {
        _dtoSettings = _dtoSettings ?? throw new ArgumentException(nameof(_dtoSettings));
            
        Console.WriteLine("Max height: " + Console.LargestWindowHeight);
        Console.WriteLine("Max width: " + Console.LargestWindowWidth);
        Console.WriteLine("Please, enter a value for the window height: ");
        _dtoSettings.WindowHeight = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
        Console.WriteLine("Please, enter a value for the window width: ");
        _dtoSettings.WindowWidth = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
        ResizeWindow();
    }
    
    private void ResizeWindow()
    {
        _dtoSettings = _dtoSettings ?? throw new ArgumentException(nameof(_dtoSettings));
#pragma warning disable CA1416
        Console.SetWindowSize(_dtoSettings.WindowWidth, _dtoSettings.WindowHeight);
        WriteToSettingsFile(_dtoSettings);
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
        _dtoSettings = _dtoSettings ?? throw new ArgumentException(nameof(_dtoSettings));
        
        Console.WriteLine("Please, enter a filename...");
        _dtoSettings.SaveFile = Console.ReadLine();
        WriteToSettingsFile(_dtoSettings);
    }
}
