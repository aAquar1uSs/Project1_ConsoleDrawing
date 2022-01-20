using System.Text.Json;
using ConsoleDrawing.Models;
using ConsoleDrawing.Tools;

namespace ConsoleDrawing.Services;

public sealed class DrawService
{
    private string SaveFile { get; set; }

    public DrawService(string filename = "save.json")
    {
        SaveFile = filename;
    }

    public void SavePictureToFile(List<Shape> shapes)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new ShapeConverter() }
        };
        var stream = File.OpenWrite(SaveFile);
        var json = JsonSerializer.Serialize(shapes, options);
        using var streamWriter = new StreamWriter(stream);
        streamWriter.WriteLine(json);
    }

    public List<Shape>? UploadFromFile()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new ShapeConverter() }
        };
        var stream = File.OpenRead(SaveFile);
        using var streamReader = new StreamReader(stream);
        var json = streamReader.ReadToEnd();
        return JsonSerializer.Deserialize<List<Shape>>(json, options);
    }
}
