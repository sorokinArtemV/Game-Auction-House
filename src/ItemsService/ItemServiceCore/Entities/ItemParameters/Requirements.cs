using System.Text.Json.Serialization;

namespace ItemsService.ItemServiceCore.Entities.ItemParameters;

public class Requirement
{
    public int Level { get; set; }
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    public string? Class { get; set; }
}