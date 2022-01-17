using System.Text.Json.Serialization;

namespace ConsoleDrawing.DTO;

public class DtoSettings
{
    [JsonPropertyName("window_width")]
    public int WindowWidth { get; set; }
    
    [JsonPropertyName("window_height")]
    public int WindowHeight { get; set; }
    
    [JsonPropertyName("save_file")]
    public string? SaveFile { get ; set ; }

    public override string ToString()
    {
        return $"Window height: {WindowHeight}" + '\n' +
               $"Window weight: {WindowWidth}" + '\n' +
               $"File to save: {SaveFile}";

    }
}
