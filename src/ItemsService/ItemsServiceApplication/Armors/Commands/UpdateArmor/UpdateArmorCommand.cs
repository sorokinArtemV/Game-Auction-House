using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.WeaponEffects.Dto;
using ItemsService.ItemsServiceApplication.Weapons.Commands.CreateWeapon;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.UpdateArmor;

public class UpdateArmorCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? ArmorType { get; set; }
    public int ArmorValue { get; set; }
    public string Quality { get; set; } = default!;
    public int ItemLevel { get; set; }
    public string Icon { get; set; } = default!;
    public bool IsStackable { get; set; }
    public int StackSize { get; set; }
    public bool IsBound { get; set; }
    public string BoundType { get; set; } = default!;
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
    public List<CreateWeaponCommand> SpecialEffects { get; set; } = [];
}