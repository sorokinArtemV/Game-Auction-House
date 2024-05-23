using GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.ArmorEffects.Commands.DeleteArmorEffect;

public class DeleteArmorEffectCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericItemsRepository<Armor> armorRepository,
    IGenericEffectsRepository<ArmorEffect> armorEffectRepository,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<DeleteArmorEffectCommand>
{
    public async Task Handle(DeleteArmorEffectCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting armor effect {Id} from armor {@ArmorEffectRequest}", request.Id, request.ArmorId);

        var armor = await armorRepository.GetByIdAsync(request.ArmorId);

        if (armor is null) throw new NotFoundException(nameof(Weapon), request.ArmorId.ToString());

        var effect = armor.SpecialEffects.FirstOrDefault(x => x.Id == request.Id);

        if (effect is null) throw new NotFoundException(nameof(WeaponEffect), request.Id.ToString());

        diagnosticContext.Set("WeaponEffects deleted", effect);

        await armorEffectRepository.DeleteAsync(effect);
    }
}