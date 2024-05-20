using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Commands.CreateArmorEffect;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Dto;

public class ArmorEffectProfile : Profile
{
    public ArmorEffectProfile()
    {
        CreateMap<CreateArmorEffectCommand, ArmorEffect>();
        CreateMap<ArmorEffect, ArmorEffectDto>();
    }
}