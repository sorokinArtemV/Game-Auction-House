using AuctionService.Entities.ItemParameters;

namespace AuctionService.DTO.ItemDto;

public class WeaponDetailsDto : IItemDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ItemLevel { get; set; }
    public string WeaponType { get; set; } = default!;
    public string DamageType { get; set; } = default!;
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double AttackSpeed { get; set; }
    public double Dps => (MinDamage + MaxDamage) / 2 / AttackSpeed;
    public bool IsTwoHanded { get; set; }
    public bool IsMainHand { get; set; }
    public bool IsOffHand { get; set; }
    public string Quality { get; set; }
    public string Icon { get; set; }
    public bool IsStackable { get; set; }
    public int StackSize { get; set; }
    public bool IsBound { get; set; }
    public string BoundType { get; set; }
    public bool IsConjured { get; set; }
    public bool IsUnique { get; set; }
    public int Durability { get; set; }
    public bool IsQuestItem { get; set; }
    public bool StartsQuest { get; set; }
    public List<string>? RequiredRace { get; set; }
    public List<string>? RequiredClasses { get; set; }
    public int RequiredLevel { get; set; }
    public List<string>? RequiredSkill { get; set; }
    public bool IsLocked { get; set; }
    public bool IsLootable { get; set; }
    public PrimaryStats? PrimaryStats { get; set; }
    public SecondaryStats? SecondaryStats { get; set; }
    public List<WeaponEffect> SpecialEffects { get; set; } = [];
}