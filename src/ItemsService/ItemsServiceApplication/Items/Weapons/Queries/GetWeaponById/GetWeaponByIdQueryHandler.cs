using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetWeaponById;

public class GetWeaponByIdQueryHandler(
    ILogger<GetWeaponByIdQueryHandler> logger,
    IGenericItemsRepository<Weapon> weaponsItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetWeaponByIdQuery, WeaponDto>
{
    public async Task<WeaponDto> Handle(GetWeaponByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting weapon with id: {id}", request.Id);
        var weapon = await weaponsItemsRepository.GetByIdAsync(request.Id)
                     ?? throw new NotFoundException(nameof(Weapon), request.Id.ToString());

        var weaponDto = mapper.Map<WeaponDto>(weapon);
        diagnosticContext.Set("Weapon", weaponDto);

        return weaponDto;
    }
}