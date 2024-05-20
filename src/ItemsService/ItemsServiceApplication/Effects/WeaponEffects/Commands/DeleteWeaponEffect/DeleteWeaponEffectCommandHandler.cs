using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.DeleteWeaponEffect;

public class DeleteWeaponEffectCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericItemsRepository<Weapon> weaponRepository,
    IGenericEffectsRepository<WeaponEffect> weaponEffectRepository,
    IDiagnosticContext diagnosticContext
    ) : IRequestHandler<DeleteWeaponEffectCommand>
{
    public async Task Handle(DeleteWeaponEffectCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Deleting weapon effect {Id} from weapon {@WeaponEffectRequest}", request.Id, request.WeaponId);
        
        var weapon = await weaponRepository.GetByIdAsync(request.WeaponId);
        
        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());
        
        var effect = weapon.SpecialEffects.FirstOrDefault(x => x.Id == request.Id);
        
        if (effect is null) throw new NotFoundException(nameof(WeaponEffect), request.Id.ToString());
        
        diagnosticContext.Set("WeaponEffects deleted", effect);
        
        await weaponEffectRepository.DeleteAsync(effect);
    }
}