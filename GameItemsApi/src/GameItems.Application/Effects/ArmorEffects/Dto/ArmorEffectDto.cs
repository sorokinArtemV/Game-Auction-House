using System.Text.Json.Serialization;

namespace GameItems.Application.Effects.ArmorEffects.Dto;

public class ArmorEffectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Charges { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsPassive { get; set; }

    [JsonIgnore] public int? ArmorId { get; set; }
}