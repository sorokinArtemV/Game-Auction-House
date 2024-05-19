using FluentValidation;
using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemsServiceApplication.Common.Validators;

public class SecondaryStatsValidator : AbstractValidator<SecondaryStats>
{
    public SecondaryStatsValidator()
    {
        RuleFor(stats => stats.CriticalStrike).GreaterThanOrEqualTo(1).When(stats => stats.CriticalStrike.HasValue);
        RuleFor(stats => stats.AttackPower).GreaterThanOrEqualTo(1).When(stats => stats.AttackPower.HasValue);
        RuleFor(stats => stats.SpellPower).GreaterThanOrEqualTo(1).When(stats => stats.SpellPower.HasValue);
        RuleFor(stats => stats.HealingPower).GreaterThanOrEqualTo(1).When(stats => stats.HealingPower.HasValue);
        RuleFor(stats => stats.ManaRegenPerSecond).GreaterThanOrEqualTo(1).When(stats => stats.ManaRegenPerSecond.HasValue);
    }
}