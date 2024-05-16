using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.Effects.Dto;
using Microsoft.Build.Framework;

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
    
    // primary stats
    public int? Strength { get; set; }
    public int? Agility { get; set; }
    public int? Stamina { get; set; }
    public int? Intellect { get; set; }
    public int? Spirit { get; set; }
    
    // secondary stats
    public int? CriticalStrike { get; set; }
    public int? AttackPower { get; set; }
    public int? SpellPower { get; set; }
    public int? HealingPower { get; set; }
    public int? ManaRegenPerSecond { get; set; }
    
    [Required]
    public PrimaryStats? PrimaryStats { get; set; }
    
    [Required]
    public SecondaryStats? SecondaryStats { get; set; }
    
    public List<EffectDto> SpecialEffects { get; set; } = [];
}