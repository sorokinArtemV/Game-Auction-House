using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemsServiceApplication.Effects.Dto;

public class EffectProfile : Profile
{
    public EffectProfile()
    {
        // TODO: Handle error when provide additional unneeded ids
        
        CreateMap<Effect, EffectDto>();

        CreateMap<CreateEffectDto, Effect>();
    }
}