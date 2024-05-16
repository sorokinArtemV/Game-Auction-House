using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemsServiceApplication.Effects.Dto;

public class EffectProfile : Profile
{
    public EffectProfile()
    {
        CreateMap<Effect, EffectDto>();
    }
}