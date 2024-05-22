using AutoMapper;
using GameItems.Application.Effects.ArmorEffects.Commands.CreateArmorEffect;
using GameItems.Core.Entities.ItemParameters;

namespace GameItems.Application.Effects.ArmorEffects.Dto;

public class ArmorEffectProfile : Profile
{
    public ArmorEffectProfile()
    {
        CreateMap<CreateArmorEffectCommand, ArmorEffect>();
        CreateMap<ArmorEffect, ArmorEffectDto>();
    }
}