using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Armors.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Queries.GetArmorById;

public class GetArmorByIdQueryHandler(
    ILogger<GetArmorByIdQuery> logger,
    IGenericItemsRepository<Armor> itemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetArmorByIdQuery, ArmorDto>
{
    public async Task<ArmorDto> Handle(GetArmorByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting armor with id: {id}", request.Id);

        var armor = await itemsRepository.GetByIdAsync(request.Id)
                    ?? throw new NotFoundException(nameof(Armor), request.Id.ToString());

        var armorDto = mapper.Map<ArmorDto>(armor);
        diagnosticContext.Set("Armor", armorDto);

        return armorDto;
    }
}