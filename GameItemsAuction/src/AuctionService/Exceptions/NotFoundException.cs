﻿namespace AuctionService.Exceptions;

public class NotFoundException(string? resourceType, string resourceIdentifier) 
    : Exception($"{resourceType} with identifier {resourceIdentifier} not found.");