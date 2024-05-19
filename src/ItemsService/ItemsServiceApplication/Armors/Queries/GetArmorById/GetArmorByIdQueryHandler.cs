using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Armors.DTO;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Queries.GetArmorById;

public class GetArmorByIdQueryHandler(
    ILogger<GetArmorByIdQuery> logger,
    IGenericRepository<Armor> repository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
    ) : IRequestHandler<GetArmorByIdQuery, ArmorDto?>
{
    public async Task<ArmorDto?> Handle(GetArmorByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting armor with id: {id}", request.Id);
        
        var armor = await repository.GetByIdAsync(request.Id);
        
        var armorDto = mapper.Map<ArmorDto>(armor);
        diagnosticContext.Set("Armor", armorDto);
        
        return armorDto;
    }
}