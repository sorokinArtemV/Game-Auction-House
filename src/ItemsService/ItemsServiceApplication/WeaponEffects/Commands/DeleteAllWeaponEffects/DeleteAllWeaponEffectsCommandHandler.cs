using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.CreateWeaponEffect;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.WeaponEffects.Commands.DeleteAllWeaponEffects;

public class DeleteAllWeaponEffectsCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericItemsRepository<Weapon> weaponRepository,
    IGenericEffectsRepository<WeaponEffect> weaponEffectRepository,
    IDiagnosticContext diagnosticContext
    ) : IRequestHandler<DeleteAllWeaponEffectsCommand>
{
    public async Task Handle(DeleteAllWeaponEffectsCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Deleting all weapon effects from weapon {@WeaponEffectRequest}", request.WeaponId);
        
        var weapon = await weaponRepository.GetByIdAsync(request.WeaponId);
        
        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());
        
        diagnosticContext.Set("WeaponEffects deleted", weapon.SpecialEffects);

        await weaponEffectRepository.DeleteAllAsync(weapon.SpecialEffects);
        
        
    }
}