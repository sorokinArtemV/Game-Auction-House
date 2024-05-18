using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Weapons.Commands.CreateWeapon;

public class CreateWeaponCommandHandler(
    ILogger<CreateWeaponCommandHandler> logger, 
    IGenericRepository<Weapon> weaponsRepository, 
    IMapper mapper
    ) : IRequestHandler<CreateWeaponCommand, int>
{
    public async Task<int> Handle(CreateWeaponCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating weapon");
        
        var weapon = mapper.Map<Weapon>(request);

        var id = await weaponsRepository.CreateAsync(weapon);
        
        return id;
    }
}