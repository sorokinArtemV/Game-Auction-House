using AuctionService.Entities.ItemParameters;

namespace AuctionService.DTO.ItemDto;

public class ArmorDetailsDto : IItemDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int ArmorValue { get; set; }
    public string Quality { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ArmorType { get; set; } = default!;
    public int ItemLevel { get; set; }
    public string Icon { get; set; } = default!;
    public bool IsBound { get; set; }
    public string BoundType { get; set; } = default!;
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
    public List<BaseEffect> SpecialEffects { get; set; } = [];
}