using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;

namespace ItemsService.ItemsServiceApplication.WeaponEffects.Commands.CreateWeaponEffect;

public class CreateWeaponEffectCommandHandler(
    ILogger<CreateWeaponEffectCommandHandler> logger,
    IGenericRepository<Weapon> weaponRepository,
    IGenericRepository<WeaponEffect> weaponEffectRepository,
    IMapper mapper
) : IRequestHandler<CreateWeaponEffectCommand>
{
    public async Task Handle(CreateWeaponEffectCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating weapon effect: {@WeaponEffectRequest}", request);

        var weapon = await weaponRepository.GetByIdAsync(request.WeaponId);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.WeaponId.ToString());

        var weaponEffect = mapper.Map<WeaponEffect>(request);

        await weaponEffectRepository.CreateAsync(weaponEffect);
    }
}