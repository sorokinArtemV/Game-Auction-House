using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Common;
using ItemsService.ItemsServiceApplication.Items.Armors.DTO;
using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Items.Armors.Queries.GetAllArmors;

public class GetAllArmorsQueryHandler(
    ILogger<GetAllArmorsQueryHandler> logger,
    IGenericItemsRepository<Armor> armorsItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetAllArmorsQuery, PagedResult<ArmorDto>>
{
    public async Task<PagedResult<ArmorDto>> Handle(GetAllArmorsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapons");

        var (armors, totalCount) = await armorsItemsRepository.GetAllMatchingAsync(
            request.SearchPhrase,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection
        );

        var armorsDto = mapper.Map<IEnumerable<ArmorDto>>(armors);
        diagnosticContext.Set("Armors", armorsDto);

        var result = new PagedResult<ArmorDto>(armorsDto, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}