using AutoMapper;
using GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using GameItems.Core.Entities.ItemParameters;

namespace GameItems.Application.Effects.WeaponEffects.Dto;

public class WeaponEffectProfile : Profile
{
    public WeaponEffectProfile()
    {
        CreateMap<CreateWeaponEffectCommand, WeaponEffect>();
        CreateMap<WeaponEffect, WeaponEffectDto>();
    }
}