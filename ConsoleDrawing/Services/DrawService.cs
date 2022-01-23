using System.Text.Json;
using ConsoleDrawing.Models;
using ConsoleDrawing.Tools;

namespace ConsoleDrawing.Services;

public sealed class DrawService
{
    private string SaveFile { get; set; }

    private readonly JsonSerializerOptions _options;
    
    public DrawService(string filename = "save.json")
    {
        SaveFile = filename;
        _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new ShapeConverter() }
        };
    }

    public void SavePictureToFile(List<Shape> shapes)
    {
        var stream = File.OpenWrite(SaveFile);
        var json = JsonSerializer.Serialize(shapes, _options);
        using var streamWriter = new StreamWriter(stream);
        streamWriter.WriteLine(json);
    }

    public List<Shape>? UploadFromFile()
    {
        var stream = File.OpenRead(SaveFile);
        using var streamReader = new StreamReader(stream);
        var json = streamReader.ReadToEnd();
        return JsonSerializer.Deserialize<List<Shape>>(json, _options);
    }
}
