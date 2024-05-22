using AutoMapper;
using GameItems.Application.Effects.WeaponEffects.Dto;
using GameItems.Application.Effects.WeaponEffects.Queries.GetAllWeaponEffects;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.WeaponEffects.Queries.GetWeaponEffectById;

public class GetWeaponEffectByIdQueryHandler(
    ILogger<GetAllWeaponEffectsQueryHandler> logger,
    IGenericItemsRepository<Weapon> weaponsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetWeaponEffectByIdQuery, WeaponEffectDto>
{
    public async Task<WeaponEffectDto> Handle(GetWeaponEffectByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting {WeaponEffect} weapon effects for weapon {WeaponId}", request.Id,
            request.WeaponId);

        var weapon = await weaponsRepository.GetByIdAsync(request.WeaponId);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());

        var effect = weapon.SpecialEffects.FirstOrDefault(x => x.Id == request.Id);

        if (effect is null) throw new NotFoundException(nameof(WeaponEffect), request.Id.ToString());


        var results = mapper.Map<WeaponEffectDto>(effect);
        diagnosticContext.Set("WeaponEffects", results);

        return results;
    }
}