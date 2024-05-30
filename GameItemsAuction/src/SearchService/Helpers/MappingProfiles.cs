﻿using AutoMapper;
using Contracts;
using SearchService.Entities;

namespace SearchService.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AuctionCreated, Item>();
    }
}