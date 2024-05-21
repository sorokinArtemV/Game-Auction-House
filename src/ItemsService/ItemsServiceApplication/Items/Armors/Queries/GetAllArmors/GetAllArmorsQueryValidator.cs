using FluentValidation;

namespace ItemsService.ItemsServiceApplication.Items.Armors.Queries.GetAllArmors;

public class GetAllArmorsQueryValidator : AbstractValidator<GetAllArmorsQuery>
{
    private readonly int[] _allowedPageSizes = [4, 8, 12];
    
    public GetAllArmorsQueryValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
        
        RuleFor(r => r.PageSize)
            .Must(p => _allowedPageSizes.Contains(p))
            .WithMessage($"Page size must in [{string.Join(",", _allowedPageSizes)}]");
    }
}