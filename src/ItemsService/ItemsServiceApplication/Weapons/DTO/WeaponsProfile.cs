using AutoMapper;
using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Weapons.Commands.CreateWeapon;

namespace ItemsService.ItemsServiceApplication.Weapons.DTO;

public class WeaponsProfile : Profile
{
    public WeaponsProfile()
    {
        // CreateDto to Weapon
        CreateMap<CreateWeaponCommand, Weapon>()
            .ForMember(d => d.PrimaryStats, opt => opt.MapFrom(src => src.PrimaryStats))
            .ForMember(d => d.SecondaryStats, opt => opt.MapFrom(src => src.SecondaryStats))
            .ForMember(d => d.SpecialEffects, opt => opt.MapFrom(src => src.SpecialEffects));
 
        // Weapon to WeaponDto
        CreateMap<Weapon, WeaponDto>()
            .ForMember(dto => dto.PrimaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Weapon, PrimaryStats>(w => w.PrimaryStats!)))
            .ForMember(dto => dto.SecondaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Weapon, SecondaryStats>(w => w.SecondaryStats!)));
    }
}
