using FluentValidation;
using ItemsService.ItemsServiceApplication.Weapons.DTO;

namespace ItemsService.ItemsServiceApplication.Weapons.Validators;

public class CreateWeaponDtoValidator : AbstractValidator<CreateWeaponDto>
{
    private readonly IEnumerable<string> _boundTypes =
    [
        "BindOnPickup",
        "BindOnEquip",
        "BindOnUse"
    ];

    private readonly IEnumerable<string> _classes =
    [
        "Any",
        "Warrior",
        "Paladin",
        "Hunter",
        "Rogue",
        "Priest",
        "Shaman",
        "Mage",
        "Warlock",
        "Druid"
    ];

    private readonly IEnumerable<string> _damageTypes =
    [
        "Physical",
        "Frost",
        "Holy",
        "Nature",
        "Shadow",
        "Arcane",
        "Fire"
    ];

    private readonly IEnumerable<string> _qualityTypes =
    [
        "Poor",
        "Common",
        "Uncommon",
        "Rare",
        "Epic",
        "Legendary"
    ];

    private readonly IEnumerable<string> _races =
    [
        "Any",
        "Human",
        "Orc",
        "Dwarf",
        "Night Elf",
        "Gnome",
        "Undead",
        "Tauren",
        "Gnome",
        "Troll"
    ];

    private readonly IEnumerable<string> _weaponTypes =
    [
        "Any",
        "Dagger",
        "Sword",
        "Axe",
        "Mace",
        "TwoHandedSword",
        "TwoHandedAxe",
        "TwoHandedMace",
        "Stave",
        "Polearm",
        "FistReward",
        "BanksBowsCrossbow",
        "Wand"
    ];

    private readonly IEnumerable<string> _primaryStats =
    [
        "Strength",
        "Agility",
        "Stamina",
        "Intellect",
        "Spirit"
    ];

    public CreateWeaponDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(3, 30)
            .WithMessage("Name must be between 3 and 30 characters");

        RuleFor(dto => dto.Description)
            .Length(3, 100)
            .WithMessage("Description must be between 3 and 100 characters");

        RuleFor(dto => dto.Quality)
            .Custom((value, context) =>
            {
                var isValid = _qualityTypes.Contains(value);
                if (!isValid)
                    context.AddFailure("Quality",
                        "Quality must be one of the following: " + string.Join(", ", _qualityTypes));
            });

        RuleFor(dto => dto.Icon)
            .Length(3, 100)
            .WithMessage("Icon must be between 3 and 100 characters");

        RuleFor(dto => dto.BoundType)
            .Custom((value, context) =>
            {
                var isValid = _boundTypes.Contains(value);
                if (!isValid)
                    context.AddFailure("BoundType",
                        "BoundType must be one of the following: " + string.Join(", ", _boundTypes));
            });

        RuleFor(dto => dto.Durability)
            .NotEmpty()
            .WithMessage("Durability is required")
            .InclusiveBetween(1, 150)
            .WithMessage("Durability must be between 1 and 60");

        RuleFor(dto => dto.StartsQuest)
            .NotNull()
            .WithMessage("StartsQuest must not be null")
            .Must(x => x || x == false)
            .WithMessage("StartsQuest must be either true or false");

        RuleFor(dto => dto.ItemLevel)
            .NotEmpty()
            .WithMessage("ItemLevel is required")
            .InclusiveBetween(1, 150)
            .WithMessage("ItemLevel must be between 1 and 60");

        RuleFor(dto => dto.StackSize)
            .NotNull()
            .WithMessage("StackSize must not be null")
            .InclusiveBetween(1, 100)
            .WithMessage("StackSize must be between 1 and 100");

        RuleFor(dto => dto.RequiredClasses)
            .NotNull() // Validates that the list is not null
            .WithMessage("RequiredClasses list must not be null")
            .Must(classes => classes!.All(@class => _classes.Contains(@class)))
            .WithMessage("Class must be one of the following: " + string.Join(", ", _classes));

        RuleFor(dto => dto.RequiredRace)
            .NotNull() // Validates that the list is not null
            .WithMessage("RequiredRace list must not be null")
            .Must(races => races!.All(race => _races.Contains(race)))
            .WithMessage("Race must be one of the following: " + string.Join(", ", _races));

        RuleFor(dto => dto.RequiredLevel)
            .NotEmpty()
            .WithMessage("RequiredLevel is required")
            .InclusiveBetween(1, 60)
            .WithMessage("RequiredLevel must be between 1 and 60");

        RuleFor(dto => dto.RequiredSkill)
            .NotNull() // Validates that the list is not null
            .WithMessage("RequiredSkill list must not be null")
            .Must(skills => skills!.All(skill => _weaponTypes.Contains(skill)))
            .WithMessage("Skill must be one of the following: " + string.Join(", ", _weaponTypes));

        RuleFor(dto => dto.WeaponType)
            .Custom((value, context) =>
            {
                var isValid = _weaponTypes.Contains(value);
                if (!isValid)
                    context.AddFailure("WeaponType",
                        "WeaponType must be one of the following: " + string.Join(", ", _weaponTypes));
            });

        RuleFor(dto => dto.DamageType)
            .Custom((value, context) =>
            {
                var isValid = _damageTypes.Contains(value);
                if (!isValid)
                    context.AddFailure("DamageType",
                        "DamageType must be one of the following: " + string.Join(", ", _damageTypes));
            });
        RuleFor(dto => dto.IsConjured)
            .NotNull();

        RuleFor(dto => dto.IsUnique)
            .NotNull();

        RuleFor(dto => dto.IsQuestItem)
            .NotNull();

        RuleFor(dto => dto.IsLocked)
            .NotNull();

        RuleFor(dto => dto.IsLootable)
            .NotNull();

        RuleFor(dto => dto.IsTwoHanded)
            .NotNull();

        RuleFor(dto => dto.IsMainHand)
            .NotNull();

        RuleFor(dto => dto.IsOffHand)
            .NotNull();
    }
}   