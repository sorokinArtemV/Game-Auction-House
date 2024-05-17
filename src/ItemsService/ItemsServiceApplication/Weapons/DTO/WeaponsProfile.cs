using AutoMapper;
using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemsServiceApplication.Weapons.DTO;

public class WeaponsProfile : Profile
{
    public WeaponsProfile()
    {
        CreateMap<Weapon, WeaponDto>()
            .ForMember(dto => dto.PrimaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Weapon, PrimaryStats>(w => w.PrimaryStats!)))
            .ForMember(dto => dto.SecondaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Weapon, SecondaryStats>(w => w.SecondaryStats!)));
    }
}