using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Commands.DeleteArmorEffect;

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