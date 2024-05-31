using FluentValidation;
using GameItems.Application.Items.Armors.DTO;

namespace GameItems.Application.Items.Armors.Queries.GetAllArmors;

public class GetAllArmorsQueryValidator : AbstractValidator<GetAllArmorsQuery>
{
    private readonly int[] _allowedPageSizes = [4, 8, 12];

    private readonly string[] _allowedSortByColumnNames =
    [
        nameof(ArmorDto.Name),
        nameof(ArmorDto.ArmorType),
        nameof(ArmorDto.RequiredLevel)
    ];

    public GetAllArmorsQueryValidator()
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