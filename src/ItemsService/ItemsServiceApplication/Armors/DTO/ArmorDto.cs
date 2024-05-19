using ItemsService.ItemsServiceApplication.Effects.Dto;

namespace ItemsService.ItemsServiceApplication.Armors.DTO;

public class ArmorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? ArmorType { get; set; }
    public int ArmorValue { get; set; }
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

    public override string ToString() => $"{Id}: {Name}";
}