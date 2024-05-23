using AutoMapper;
using GameItems.Application.Items.Weapons.DTO;

namespace GameItems.Application.Helpers;

public interface IStatsParamsValueResolver<TSource, TStats> where TSource : class where TStats : class
{
    Dictionary<string, int?> Resolve(
        TSource source,
        WeaponDto destination,
        Dictionary<string, int?> destMember,
        ResolutionContext context);
}