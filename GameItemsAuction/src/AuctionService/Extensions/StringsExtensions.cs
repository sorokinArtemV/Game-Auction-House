namespace AuctionService.Extensions;

public static class StringsExtensions
{
    public static string Capitalize(this string str)
    {
        if (string.IsNullOrEmpty(str)) return str; 
        var firstChar = char.ToUpperInvariant(str[0]);
        
        return firstChar + str[1..];
    }
}