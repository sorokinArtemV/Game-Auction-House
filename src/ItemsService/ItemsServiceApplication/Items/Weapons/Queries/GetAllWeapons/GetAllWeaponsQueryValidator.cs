using FluentValidation;

namespace ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQueryValidator : AbstractValidator<GetAllWeaponsQuery>
{
    private readonly int[] _allowedPageSizes = [4, 8, 12];
    
    public GetAllWeaponsQueryValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
        
        RuleFor(r => r.PageSize)
            .Must(p => _allowedPageSizes.Contains(p))
            .WithMessage($"Page size must in [{string.Join(",", _allowedPageSizes)}]");
    }
}