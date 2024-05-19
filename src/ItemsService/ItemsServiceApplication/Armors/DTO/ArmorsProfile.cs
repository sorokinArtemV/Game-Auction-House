using AutoMapper;
using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemsServiceApplication.Armors.DTO;

public class ArmorsProfile : Profile
{
    public ArmorsProfile()
    {
        // Armor to ArmorDto
        CreateMap<Armor, ArmorDto>()
            .ForMember(dto => dto.PrimaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Armor, ArmorDto, PrimaryStats>(w => w.PrimaryStats!)))
            .ForMember(dto => dto.SecondaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Armor, ArmorDto, SecondaryStats>(w => w.SecondaryStats!)));
    }
}
