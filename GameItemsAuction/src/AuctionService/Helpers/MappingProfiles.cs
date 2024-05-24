using AuctionService.DTO;
using AuctionService.DTO.ItemDto;
using AuctionService.Entities;
using AuctionService.Entities.ItemTypes;
using AutoMapper;

namespace AuctionService.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>();
        CreateMap<Weapon, WeaponDetailsDto>();
        CreateMap<Armor, ArmorDetailsDto>();
        // CreateMap<BaseItem, AuctionDto>()
        //     .Include<Weapon, AuctionDto>(); // Include derived type Weapon
        // CreateMap<Weapon, AuctionDto>()
        //     .ForMember(dest => dest.BaseItem, opt => opt.MapFrom(src => src)); // Map Weapon to BaseItem

        // CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        //
        // CreateMap<Item, AuctionDto>();
        //
        // CreateMap<CreateAuctionDto, Auction>()
        //     .ForMember(d => d.Item, opt => opt.MapFrom(s => s));
        //
        // CreateMap<CreateAuctionDto, Item>();
    }
}