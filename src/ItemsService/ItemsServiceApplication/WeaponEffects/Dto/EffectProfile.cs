using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.CreateWeaponEffect;

namespace ItemsService.ItemsServiceApplication.WeaponEffects.Dto;

public class EffectProfile : Profile
{
    public EffectProfile()
    {
        CreateMap<CreateWeaponEffectCommand, WeaponEffect>();
        CreateMap<WeaponEffect, WeaponEffectDto>();
    }
}