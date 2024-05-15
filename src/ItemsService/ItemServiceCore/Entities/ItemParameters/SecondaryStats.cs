using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ItemsService.ItemServiceCore.Entities.ItemParameters;

public class SecondaryStats
{
    [ForeignKey("Weapon")]
    [JsonIgnore]
    public int WeaponId { get; set; }
    public int? CriticalStrike { get; set; }
    public int? AttackPower { get; set; }
    public int? SpellPower { get; set; }
    public int? HealingPower { get; set; }
    public int? ManaRegenPerSecond { get; set; }
}
