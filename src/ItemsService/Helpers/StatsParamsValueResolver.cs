using AutoMapper;
using ItemsService.ItemsServiceApplication.Weapons.DTO;

namespace ItemsService.Helpers;

public class StatsParamsValueResolver<TSource, TStats> 
    : IValueResolver<TSource, WeaponDto, Dictionary<string, int?>>, IStatsParamsValueResolver<TSource, TStats> 
    where TSource : class
    where TStats : class
{
    private readonly Func<TSource, TStats> _statsSelector;

    public StatsParamsValueResolver(Func<TSource, TStats> statsSelector)
    {
        _statsSelector = statsSelector;
    }

    public Dictionary<string, int?> Resolve(
        TSource source, 
        WeaponDto destination, 
        Dictionary<string, int?> destMember, 
        ResolutionContext context)
    {
        var statsObject = _statsSelector(source);
        var stats = new Dictionary<string, int?>();
        var properties = typeof(TStats).GetProperties();

        foreach (var property in properties)
        {
            // Ensure the property is of type int?
            if (property.PropertyType == typeof(int?))
            {
                var value = property.GetValue(statsObject) as int?;
                
                if (value.HasValue) stats.Add(property.Name, value);
                
            }
        }

        return stats;
    }
}