namespace AuctionService.Exceptions;

public class NotSavedToDatabaseException(string? resourceType)
    : Exception($"{resourceType} was not saved to database.");