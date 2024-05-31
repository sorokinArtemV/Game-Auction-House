using AutoMapper;
using GameItems.Application.Common;
using GameItems.Application.Items.Armors.DTO;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Items.Armors.Queries.GetAllArmors;

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