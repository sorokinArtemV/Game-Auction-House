using AuctionService.DTO;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>();
        CreateMap<AuctionDto, AuctionCreated>();
    }
}