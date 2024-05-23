using AutoMapper;
using GameItems.Application.Items.Armors.DTO;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Items.Armors.Queries.GetArmorById;

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