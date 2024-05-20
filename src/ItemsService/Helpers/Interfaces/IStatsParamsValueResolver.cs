using AutoMapper;
using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;

namespace ItemsService.Helpers.Interfaces;

public interface IStatsParamsValueResolver<TSource, TStats> where TSource : class where TStats : class
{
    Dictionary<string, int?> Resolve(
        TSource source, 
        WeaponDto destination, 
        Dictionary<string, int?> destMember, 
        ResolutionContext context);
}