using AuctionService.Entities.ItemParameters;

namespace AuctionService.DTO.ItemDto;

public class ArmorDetailsDto : IItemDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ArmorValue { get; set; }
    public string Quality { get; set; }
    public string Description { get; set; }
    public string ArmorType { get; set; }
    public int ItemLevel { get; set; }
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
    public List<BaseEffect> SpecialEffects { get; set; } = [];
}