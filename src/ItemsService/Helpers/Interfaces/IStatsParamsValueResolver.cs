using AutoMapper;
using ItemsService.ItemsServiceApplication.Weapons.DTO;

namespace ItemsService.Helpers;

public interface IStatsParamsValueResolver<TSource, TStats> where TSource : class where TStats : class
{
    Dictionary<string, int?> Resolve(
        TSource source, 
        WeaponDto destination, 
        Dictionary<string, int?> destMember, 
        ResolutionContext context);
}