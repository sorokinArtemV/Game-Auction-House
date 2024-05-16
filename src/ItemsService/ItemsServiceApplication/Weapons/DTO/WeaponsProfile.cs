using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemsServiceApplication.Weapons.DTO;

public class WeaponsProfile : Profile
{
    public WeaponsProfile()
    {
        CreateMap<Weapon, WeaponDto>()
            .ForMember(d => d.PrimaryStats, o =>
            {
                o.Condition(s => s.IsTwoHanded); // Exclude if false
                o.Condition(s => s.IsMainHand);
                o.Condition(s => s.IsTwoHanded);
                o.Condition(s => s.IsUnique);
            })
            .ForMember(d => d.PrimaryStats.Strength, opt => opt.Condition((src, dest, srcMember) => srcMember != null))
            .ForMember(d => d.PrimaryStats.Agility, opt => opt.Condition((src, dest, srcMember) => srcMember != null))
            .ForMember(d => d.PrimaryStats.Stamina, opt => opt.Condition((src, dest, srcMember) => srcMember != null))
            .ForMember(d => d.PrimaryStats.Intellect, opt => opt.Condition((src, dest, srcMember) => srcMember != null))
            .ForMember(d => d.PrimaryStats.Spirit, opt => opt.Condition((src, dest, srcMember) => srcMember != null))
            .ForMember(d => d.SpecialEffects, opt => opt.MapFrom(src => src.SpecialEffects));
    }
}