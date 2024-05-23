using FluentValidation;
using GameItems.Core.Entities.ItemParameters;

namespace GameItems.Application.Common.Validators;

public class PrimaryStatsValidator : AbstractValidator<PrimaryStats>
{
    public PrimaryStatsValidator()
    {
        RuleFor(stats => stats.Strength).GreaterThanOrEqualTo(1).When(stats => stats.Strength.HasValue);
        RuleFor(stats => stats.Agility).GreaterThanOrEqualTo(1).When(stats => stats.Agility.HasValue);
        RuleFor(stats => stats.Stamina).GreaterThanOrEqualTo(1).When(stats => stats.Stamina.HasValue);
        RuleFor(stats => stats.Intellect).GreaterThanOrEqualTo(1).When(stats => stats.Intellect.HasValue);
        RuleFor(stats => stats.Spirit).GreaterThanOrEqualTo(1).When(stats => stats.Spirit.HasValue);
    }
}