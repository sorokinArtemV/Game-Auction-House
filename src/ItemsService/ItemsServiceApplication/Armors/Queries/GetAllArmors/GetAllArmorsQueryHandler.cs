using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Armors.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Queries.GetAllArmors;

public class GetAllArmorsQueryHandler(
    ILogger<GetAllArmorsQueryHandler> logger,
    IGenericItemsRepository<Armor> itemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetAllArmorsQuery, IEnumerable<ArmorDto>>
{
    public async Task<IEnumerable<ArmorDto>> Handle(GetAllArmorsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all armors");

        var armors = await itemsRepository.GetAllAsync();

        var armorsDto = mapper.Map<IEnumerable<ArmorDto>>(armors);
        diagnosticContext.Set("Armors", armorsDto);

        return armorsDto;
    }
}