using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Common;
using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQueryHandler(
    ILogger<GetAllWeaponsQueryHandler> logger,
    IGenericItemsRepository<Weapon> weaponsItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetAllWeaponsQuery, PagedResult<WeaponDto>>
{
    public async Task<PagedResult<WeaponDto>> Handle(GetAllWeaponsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapons");

        var (weapons, totalCount) = await weaponsItemsRepository.GetAllMatchingAsync(
            request.SearchPhrase,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection
        );

        var weaponsDto = mapper.Map<IEnumerable<WeaponDto>>(weapons);
        diagnosticContext.Set("Weapons", weaponsDto);

        var result = new PagedResult<WeaponDto>(weaponsDto, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}