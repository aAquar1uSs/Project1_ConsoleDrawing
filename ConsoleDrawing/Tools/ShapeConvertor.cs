using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleDrawing.Models;

namespace ConsoleDrawing.Tools;

public class ShapeConverter : JsonConverter<Shape>
{
    private enum TypeDiscriminator
    {
        Circle = 1,
        Line = 2,
        Rectangle = 3,
        Square = 4,
        Triangle = 5
    }

    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(Shape).IsAssignableFrom(typeToConvert);
    }

    public override Shape Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        if (!reader.Read()
            || reader.TokenType != JsonTokenType.PropertyName
            || reader.GetString() != "TypeDiscriminator")
        {
            throw new JsonException();
        }

        if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        Shape? baseClass;
        var typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
        switch (typeDiscriminator)
        {
            case TypeDiscriminator.Circle:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }

                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                baseClass = (Circle)JsonSerializer.Deserialize(ref reader, typeof(Circle))!;
                break;
            
            case TypeDiscriminator.Line:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }

                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                baseClass = (Line)JsonSerializer.Deserialize(ref reader, typeof(Line))!;
                break;
            
            case TypeDiscriminator.Rectangle:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }

                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                baseClass = (Rectangle)JsonSerializer.Deserialize(ref reader, typeof(Rectangle))!;
                break;
            
            case TypeDiscriminator.Square:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }

                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                baseClass = (Square)JsonSerializer.Deserialize(ref reader, typeof(Square))!;
                break;
            
            case TypeDiscriminator.Triangle:
                if (!reader.Read() || reader.GetString() != "TypeValue")
                {
                    throw new JsonException();
                }

                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                baseClass = (Triangle)JsonSerializer.Deserialize(ref reader, typeof(Triangle))!;
                break;
            
            default:
                throw new NotSupportedException();
        }

        if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
        {
            throw new JsonException();
        }

        return baseClass;
    }

    public override void Write(Utf8JsonWriter writer, Shape value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        switch (value)
        {
            case Circle circle:
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Circle);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, circle);
                break;
            
            case Line line:
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Line);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, line);
                break;
            
            case Square square:
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Square);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, square);
                break;
            
            case Rectangle rect:
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Rectangle);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, rect);
                break;
            
            case Triangle triangle:
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Triangle);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, triangle);
                break;
            
            default:
                throw new NotSupportedException();
        }

        writer.WriteEndObject();
    }
}
