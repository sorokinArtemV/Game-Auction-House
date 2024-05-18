﻿using FluentValidation;
using ItemsService.ItemsServiceApplication.Effects.Dto;

namespace ItemsService.ItemsServiceApplication.Effects.Validators;

public class CreateEffectDtoValidator : AbstractValidator<CreateEffectDto>
{
    public CreateEffectDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Effect name is required.");
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Effect description is required.");
        RuleFor(dto => dto.Charges).NotEmpty().WithMessage("Effect charges is required.");
        RuleFor(dto => dto.Duration).NotEmpty().WithMessage("Effect duration is required.");
    }
}