namespace AuctionService.Extensions;

public static class StringsExtensions
{
    public static string Capitalize(this string str)
    {
        if (string.IsNullOrEmpty(str)) return str; 
        char firstChar = char.ToUpperInvariant(str[0]);
        
        return firstChar + str.Substring(1);
    }
}