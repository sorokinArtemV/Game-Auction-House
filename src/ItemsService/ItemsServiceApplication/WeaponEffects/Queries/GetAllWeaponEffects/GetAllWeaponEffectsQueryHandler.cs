using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.WeaponEffects.Dto;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.WeaponEffects.Queries.GetAllWeaponEffects;

public class GetAllWeaponEffectsQueryHandler(
    ILogger<GetAllWeaponEffectsQueryHandler> logger,
    IGenericItemsRepository<Weapon> weaponsItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetAllWeaponEffectsQuery, IEnumerable<WeaponEffectDto>>
{
    public async Task<IEnumerable<WeaponEffectDto>> Handle(GetAllWeaponEffectsQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapon effects for weapon {WeaponId}", request.WeaponId);

        var weapon = await weaponsItemsRepository.GetByIdAsync(request.WeaponId);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());

        var results = mapper.Map<IEnumerable<WeaponEffectDto>>(weapon.SpecialEffects);
        diagnosticContext.Set("WeaponEffects", results);

        return results;
    }
}