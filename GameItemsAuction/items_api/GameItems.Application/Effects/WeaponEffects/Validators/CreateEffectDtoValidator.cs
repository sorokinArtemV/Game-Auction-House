using FluentValidation;
using GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;

namespace GameItems.Application.Effects.WeaponEffects.Validators;

public class CreateEffectDtoValidator : AbstractValidator<CreateWeaponEffectCommand>
{
    public CreateEffectDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Effect name is required.");
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Effect description is required.");
        RuleFor(dto => dto.Charges).NotEmpty().WithMessage("Effect charges is required.");
        RuleFor(dto => dto.Duration).NotEmpty().WithMessage("Effect duration is required.");
    }
}