using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.CreateWeaponEffect;

namespace ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Dto;

public class WeaponEffectProfile : Profile
{
    public WeaponEffectProfile()
    {
        CreateMap<CreateWeaponEffectCommand, WeaponEffect>();
        CreateMap<WeaponEffect, WeaponEffectDto>();
    }
}