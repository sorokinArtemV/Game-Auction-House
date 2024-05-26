using MongoDB.Entities;

namespace SearchService.Entities;

public class Item : Entity
{
    public string? Seller { get; set; }
    public string? Winner { get; set; }
    public int SoldAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string? Status { get; set; }
    public int CurrentHighBid { get; set; }
    public int ReservePrice { get; set; }
    public int RequiredLevel { get; set; }
    // public ItemDetails? ItemDetails { get; set; }
}

public class Weapon: Item
{
    public WeaponDetails? ItemDetails { get; set; }
}

public class Armor: Item
{
    public ArmorDetails? ItemDetails { get; set; }
}

public class WeaponDetails : IWeaponDetails
{
    public WeaponDetails ItemDetails { get; set; }
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

public class ArmorDetails : IArmorDetails
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

public class ItemDetails : IItemDetails
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