using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ItemsService.ItemServiceCore.Constants;

namespace ItemsService.ItemServiceCore.Entities.ItemParameters;

public class Requirement
{
    public int Level { get; set; }

    [EnumDataType(typeof(GameClass))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public string? Class { get; set; }
}