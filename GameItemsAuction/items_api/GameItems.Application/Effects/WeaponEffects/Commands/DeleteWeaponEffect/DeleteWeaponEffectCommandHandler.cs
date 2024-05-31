using GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.WeaponEffects.Commands.DeleteWeaponEffect;

public class DeleteWeaponEffectCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericItemsRepository<Weapon> weaponRepository,
    IGenericEffectsRepository<WeaponEffect> weaponEffectRepository,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<DeleteWeaponEffectCommand>
{
    public async Task Handle(DeleteWeaponEffectCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning(
            "Deleting weapon effect {Id} from weapon {@WeaponEffectRequest}", request.Id, request.WeaponId);

        var weapon = await weaponRepository.GetByIdAsync(request.WeaponId);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());

        var effect = weapon.SpecialEffects.FirstOrDefault(x => x.Id == request.Id);

        if (effect is null) throw new NotFoundException(nameof(WeaponEffect), request.Id.ToString());

        diagnosticContext.Set("WeaponEffects deleted", effect);

        await weaponEffectRepository.DeleteAsync(effect);
    }
}