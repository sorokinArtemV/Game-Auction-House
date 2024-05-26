namespace SearchService.Entities;

public interface  IItemDetails
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Quality { get; set; }
    public string Description { get; set; }
    public int ItemLevel { get; set; }
    public string Icon { get; set; }
    public bool IsBound { get; set; }
    public string BoundType { get; set; }
    public bool IsConjured { get; set; }
    public bool IsUnique { get; set; }
    public int Durability { get; set; }
    public bool IsQuestItem { get; set; }
    public List<string>? RequiredRace { get; set; }
    public List<string>? RequiredClasses { get; set; }
    public int RequiredLevel { get; set; }
    public List<string>? RequiredSkill { get; set; }
    public PrimaryStats? PrimaryStats { get; set; }
    public SecondaryStats? SecondaryStats { get; set; }
    public List<BaseEffect> SpecialEffects { get; set; }
}

public class BaseEffect
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Charges { get; set; }

    public TimeSpan Duration { get; set; }
    public bool IsPassive { get; set; }
}

public class PrimaryStats
{
    public int? Strength { get; set; }
    public int? Agility { get; set; }
    public int? Stamina { get; set; }
    public int? Intellect { get; set; }
    public int? Spirit { get; set; }
}

public class SecondaryStats
{
    public int? CriticalStrike { get; set; }
    public int? AttackPower { get; set; }
    public int? SpellPower { get; set; }
    public int? HealingPower { get; set; }
    public int? ManaRegenPerSecond { get; set; }
}

public interface IArmorDetails : IItemDetails
{
    public string ArmorType { get; set; } 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Quality { get; set; }
    public string Description { get; set; }
    public int ItemLevel { get; set; }
    public string Icon { get; set; }
    public bool IsBound { get; set; }
    public string BoundType { get; set; }
    public bool IsConjured { get; set; }
    public bool IsUnique { get; set; }
    public int Durability { get; set; }
    public bool IsQuestItem { get; set; }
    public List<string>? RequiredRace { get; set; }
    public List<string>? RequiredClasses { get; set; }
    public int RequiredLevel { get; set; }
    public List<string>? RequiredSkill { get; set; }
    public PrimaryStats? PrimaryStats { get; set; }
    public SecondaryStats? SecondaryStats { get; set; }
    public List<BaseEffect> SpecialEffects { get; set; }
}

public interface IWeaponDetails : IItemDetails
{
    public string WeaponType { get; set; } 
    public string DamageType { get; set; } 
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double AttackSpeed { get; set; }
    public bool IsTwoHanded { get; set; }
    public bool IsMainHand { get; set; }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Quality { get; set; }
    public string Description { get; set; }
    public int ItemLevel { get; set; }
    public string Icon { get; set; }
    public bool IsBound { get; set; }
    public string BoundType { get; set; }
    public bool IsConjured { get; set; }
    public bool IsUnique { get; set; }
    public int Durability { get; set; }
    public bool IsQuestItem { get; set; }
    public List<string>? RequiredRace { get; set; }
    public List<string>? RequiredClasses { get; set; }
    public int RequiredLevel { get; set; }
    public List<string>? RequiredSkill { get; set; }
    public PrimaryStats? PrimaryStats { get; set; }
    public SecondaryStats? SecondaryStats { get; set; }
    public List<BaseEffect> SpecialEffects { get; set; }
}
