using FluentValidation;
using GameItems.Application.Items.Weapons.DTO;

namespace GameItems.Application.Items.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQueryValidator : AbstractValidator<GetAllWeaponsQuery>
{
    private readonly int[] _allowedPageSizes = [4, 8, 12];

    private readonly string[] _allowedSortByColumnNames =
    [
        nameof(WeaponDto.Name),
        nameof(WeaponDto.WeaponType),
        nameof(WeaponDto.RequiredLevel)
    ];

    public GetAllWeaponsQueryValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize)
            .Must(p => _allowedPageSizes.Contains(p))
            .WithMessage($"Page size must in [{string.Join(",", _allowedPageSizes)}]");

        RuleFor(r => r.SortBy)
            .Must(value => _allowedSortByColumnNames.Contains(value))
            .When(q => q.SortBy != null)
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", _allowedSortByColumnNames)}]");

        RuleFor(r => r.SortDirection)
            .IsInEnum();
    }
}