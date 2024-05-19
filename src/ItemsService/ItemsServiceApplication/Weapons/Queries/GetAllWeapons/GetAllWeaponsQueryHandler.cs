using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Weapons.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQueryHandler(
    ILogger<GetAllWeaponsQueryHandler> logger,
    IGenericRepository<Weapon> weaponsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetAllWeaponsQuery, IEnumerable<WeaponDto>>
{
    public async Task<IEnumerable<WeaponDto>> Handle(GetAllWeaponsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapons");

        var weapons = await weaponsRepository.GetAllAsync();

        var weaponsDto = mapper.Map<IEnumerable<WeaponDto>>(weapons);
        diagnosticContext.Set("Weapons", weaponsDto);

        return weaponsDto;
    }
}