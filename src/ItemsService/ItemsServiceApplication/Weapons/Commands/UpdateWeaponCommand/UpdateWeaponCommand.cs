using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.CreateWeaponEffect;
using ItemsService.ItemsServiceApplication.WeaponEffects.Dto;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Weapons.Commands.UpdateWeaponCommand;

public class UpdateWeaponCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
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
    public string WeaponType { get; set; } = default!;
    public string DamageType { get; set; } = default!;
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double AttackSpeed { get; set; }
    public bool IsTwoHanded { get; set; }
    public bool IsMainHand { get; set; }
    public bool IsOffHand { get; set; }
    public PrimaryStats? PrimaryStats { get; set; }
    public SecondaryStats? SecondaryStats { get; set; }
    public List<CreateWeaponEffectCommand> SpecialEffects { get; set; } = [];
}