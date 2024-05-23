using AuctionService.DTO;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        
        CreateMap<Item, AuctionDto>();
        
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(d => d.Item, opt => opt.MapFrom(s => s));

        CreateMap<CreateAuctionDto, Item>();
    }
}