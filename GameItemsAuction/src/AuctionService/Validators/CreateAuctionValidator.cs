using AuctionService.DTO;
using FluentValidation;

namespace AuctionService.Validators;

public class CreateAuctionValidator : AbstractValidator<CreateAuctionDto>
{
    private readonly IEnumerable<string> _itemTypes = ["weapon", "armor"];

    public CreateAuctionValidator()
    {
        RuleFor(dto => dto.ItemType)
            .NotEmpty()
            .Must(_itemTypes.Contains);

        RuleFor(dto => dto.ItemId)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(dto => dto.ReservePrice)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(dto => dto.AuctionEnd)
            .NotEmpty()
            .GreaterThan(DateTime.Now)
            .LessThan(DateTime.Now.AddDays(15));
    }
}