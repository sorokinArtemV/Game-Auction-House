using AutoMapper;
using GameItems.Application.Helpers;
using GameItems.Application.Items.Weapons.Commands.CreateWeapon;
using GameItems.Application.Items.Weapons.Commands.UpdateWeaponCommand;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;

namespace GameItems.Application.Items.Weapons.DTO;

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
                opt => opt.MapFrom(new StatsParamsValueResolver<Weapon, WeaponDto, PrimaryStats>(w => w.PrimaryStats!)))
            .ForMember(dto => dto.SecondaryStats,
                opt => opt.MapFrom(
                    new StatsParamsValueResolver<Weapon, WeaponDto, SecondaryStats>(w => w.SecondaryStats!)));

        // UpdateDto to Weapon
        CreateMap<UpdateWeaponCommand, Weapon>();
    }
}