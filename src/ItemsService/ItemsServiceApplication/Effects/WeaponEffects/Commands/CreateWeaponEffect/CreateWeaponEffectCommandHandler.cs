﻿using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.CreateWeaponEffect;

public class CreateWeaponEffectCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericItemsRepository<Weapon> weaponItemsRepository,
    IGenericEffectsRepository<WeaponEffect> weaponEffectItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<CreateWeaponEffectCommand, int>
{
    public async Task<int> Handle(CreateWeaponEffectCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating weapon effect: {@WeaponEffectRequest}", request);

        var weapon = await weaponItemsRepository.GetByIdAsync(request.WeaponId);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());

        var weaponEffect = mapper.Map<WeaponEffect>(request);
        diagnosticContext.Set("WeaponEffect created", weaponEffect);

       return await weaponEffectItemsRepository.CreateAsync(weaponEffect);
    }
}