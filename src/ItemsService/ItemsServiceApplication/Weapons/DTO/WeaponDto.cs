using ItemsService.ItemsServiceApplication.Effects.Dto;

namespace ItemsService.ItemsServiceApplication.Weapons.DTO;

public class WeaponDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string WeaponType { get; set; } = default!;
    public string DamageType { get; set; } = default!;
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double AttackSpeed { get; set; }
    public double Dps => (MinDamage + MaxDamage) / 2 / AttackSpeed;
    public bool IsTwoHanded { get; set; }
    public bool IsMainHand { get; set; }
    public bool IsOffHand { get; set; }
    public string Icon { get; set; } = default!;
    public string Quality { get; set; } = default!;
    public int ItemLevel { get; set; }
    public string BoundType { get; set; } = default!;
    public bool IsUnique { get; set; }
    public int Durability { get; set; }
    public List<string>? RequiredRace { get; set; }
    public List<string>? RequiredClasses { get; set; }
    public int RequiredLevel { get; set; }
    public List<string>? RequiredSkill { get; set; }

    public Dictionary<string, int?> PrimaryStats { get; set; } = new();
    public Dictionary<string, int?> SecondaryStats { get; set; } = new();

    public List<EffectDto> SpecialEffects { get; set; } = [];
}