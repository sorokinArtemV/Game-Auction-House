using AuctionService.DTO;
using FluentValidation;

namespace AuctionService.Validators;

public class CreateAuctionValidator : AbstractValidator<CreateAuctionDto>
{
    private readonly IEnumerable<string> _itemTypes = ["weapon", "armor"];
    
    public CreateAuctionValidator()
    {
        RuleFor(dto => dto.ItemType)
            .Must(_itemTypes.Contains);

        RuleFor(dto => dto.ItemId)
            .GreaterThan(0);
        
        RuleFor(dto => dto.ReservePrice)
            .GreaterThan(0);
        
        RuleFor(dto => dto.AuctionEnd)
            .GreaterThan(DateTime.Now);
    }
}