using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQueryHandler(
    ILogger<GetAllWeaponsQueryHandler> logger,
    IGenericItemsRepository<Weapon> weaponsItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetAllWeaponsQuery, IEnumerable<WeaponDto>>
{
    public async Task<IEnumerable<WeaponDto>> Handle(GetAllWeaponsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapons");

        var weapons = await weaponsItemsRepository.GetAllMatchingAsync(
            request.SearchPhrase,
            request.PageSize,
            request.PageNumber
            );

        var weaponsDto = mapper.Map<IEnumerable<WeaponDto>>(weapons);
        diagnosticContext.Set("Weapons", weaponsDto);

        return weaponsDto;
    }
}