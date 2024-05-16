using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItemsService.ItemServiceCore.Entities.ItemParameters;

public class Effect
{
    // [Key]
    // [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Charges { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsPassive { get; set; }

    // [JsonIgnore]
    public int? WeaponId { get; set; }
    
    // [JsonIgnore]
    public int? ArmorId { get; set; }
}