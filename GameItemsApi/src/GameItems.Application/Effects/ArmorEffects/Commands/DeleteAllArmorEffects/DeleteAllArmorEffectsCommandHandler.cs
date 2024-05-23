using GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.ArmorEffects.Commands.DeleteAllArmorEffects;

public class DeleteAllArmorEffectsCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericItemsRepository<Armor> armorRepository,
    IGenericEffectsRepository<ArmorEffect> armorEffectsRepository,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<DeleteAllArmorEffectsCommand>
{
    public async Task Handle(DeleteAllArmorEffectsCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting all armor effects from armor {@ArmorEffectRequest}", request.ArmorId);

        var armor = await armorRepository.GetByIdAsync(request.ArmorId);

        if (armor is null) throw new NotFoundException(nameof(Armor), request.ArmorId.ToString());

        diagnosticContext.Set("ArmorEffects deleted", armor.SpecialEffects);

        await armorEffectsRepository.DeleteAllAsync(armor.SpecialEffects);
    }
}