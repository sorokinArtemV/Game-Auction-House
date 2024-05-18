using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Weapons.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Weapons.Queries.GetWeaponById;

public class GetWeaponByIdQueryHandler(
    ILogger<GetWeaponByIdQueryHandler> logger,
    IGenericRepository<Weapon> weaponsRepository,
    IMapper mapper,
    IDiagnosticContext  diagnosticContext
    ) : IRequestHandler<GetWeaponByIdQuery, WeaponDto?>
{
    public async Task<WeaponDto?> Handle(GetWeaponByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting weapon with id: {id}", request.Id);
        var weapon = await weaponsRepository.GetByIdAsync(request.Id);

        var weaponDto = mapper.Map<WeaponDto>(weapon);
        diagnosticContext.Set("Weapon", weaponDto);
        
        return weaponDto;
    }
}