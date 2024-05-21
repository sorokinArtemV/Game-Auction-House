using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Commands.DeleteAllArmorEffects;

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