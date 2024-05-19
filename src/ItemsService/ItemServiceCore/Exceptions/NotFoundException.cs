namespace ItemsService.ItemServiceCore.Exceptions;

public class NotFoundException(string? message) : Exception(message);