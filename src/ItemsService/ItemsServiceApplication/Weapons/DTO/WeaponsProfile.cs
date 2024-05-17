using AutoMapper;
using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemsServiceApplication.Weapons.DTO;

public class WeaponsProfile : Profile
{
    public WeaponsProfile()
    {
        CreateMap<CreateWeaponDto, Weapon>()
            .ForMember(d => d.PrimaryStats, opt => opt.MapFrom(src => src.PrimaryStats))
            .ForMember(d => d.SecondaryStats, opt => opt.MapFrom(src => src.SecondaryStats));
        // CreateMap<CreateWeaponDto, Weapon>()
        //     .ForMember(d => d.PrimaryStats, opt => opt.MapFrom(
        //         src => new PrimaryStats
        //         {
        //             Strength = src.PrimaryStats.Strength,
        //             Agility = src.PrimaryStats.Agility,
        //             Stamina = src.PrimaryStats.Stamina,
        //             Intellect = src.PrimaryStats.Intellect,
        //             Spirit = src.PrimaryStats.Spirit
        //
        //         }))
        //     .ForMember(d => d.SecondaryStats, opt => opt.MapFrom(
        //         src => new SecondaryStats
        //         {
        //             CriticalStrike = src.SecondaryStats.CriticalStrike,
        //             AttackPower = src.SecondaryStats.AttackPower,
        //             HealingPower = src.SecondaryStats.HealingPower,
        //             SpellPower = src.SecondaryStats.SpellPower,
        //             ManaRegenPerSecond = src.SecondaryStats.ManaRegenPerSecond
        //
        //         }));
        
            // .ForMember(d => d.SpecialEffects, opt => opt.MapFrom(
            //     src => src.SpecialEffects.Select(effect => new Effect
            //     {
            //         Name = effect.Name,
            //         Description = effect.Description,
            //         Duration = effect.Duration,
            //         Charges = effect.Charges,
            //         IsPassive = effect.IsPassive
            //     }).ToList()));

        CreateMap<Weapon, WeaponDto>()
            .ForMember(dto => dto.PrimaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Weapon, PrimaryStats>(w => w.PrimaryStats!)))
            .ForMember(dto => dto.SecondaryStats,
                opt => opt.MapFrom(new StatsParamsValueResolver<Weapon, SecondaryStats>(w => w.SecondaryStats!)));
    }
}
