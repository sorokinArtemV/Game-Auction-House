namespace GameItems.Core.Entities.ItemParameters;

public class Requirement
{
    public int Level { get; set; }
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    public string? Class { get; set; }
}