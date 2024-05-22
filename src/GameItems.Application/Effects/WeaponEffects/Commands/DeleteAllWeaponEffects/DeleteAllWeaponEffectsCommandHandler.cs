using GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.WeaponEffects.Commands.DeleteAllWeaponEffects;

public class DeleteAllWeaponEffectsCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericItemsRepository<Weapon> weaponRepository,
    IGenericEffectsRepository<WeaponEffect> weaponEffectRepository,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<DeleteAllWeaponEffectsCommand>
{
    public async Task Handle(DeleteAllWeaponEffectsCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning(
            "Deleting all weapon effects from weapon {@WeaponEffectRequest}", request.WeaponId);

        var weapon = await weaponRepository.GetByIdAsync(request.WeaponId);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());

        diagnosticContext.Set("WeaponEffects deleted", weapon.SpecialEffects);

        await weaponEffectRepository.DeleteAllAsync(weapon.SpecialEffects);
    }
}