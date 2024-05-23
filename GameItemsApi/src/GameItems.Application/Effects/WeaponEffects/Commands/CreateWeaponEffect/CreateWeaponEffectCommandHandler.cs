using AutoMapper;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;

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