using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Dto;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Queries.GetAllArmorEffects;

public class GetAllArmorEffectsQueryHandler(
    ILogger<GetAllArmorEffectsQueryHandler> logger,
    IGenericItemsRepository<Armor> armorRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
    ) : IRequestHandler< GetAllArmorEffectsQuery, IEnumerable<ArmorEffectDto>>
{
    public async Task<IEnumerable<ArmorEffectDto>> Handle(GetAllArmorEffectsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapon effects for weapon {ArmorId}", request.ArmorId);
        
        var armor = await armorRepository.GetByIdAsync(request.ArmorId);
        
        if(armor is null) throw new NotFoundException(nameof(Armor), request.ArmorId.ToString());

        var results = mapper.Map<IEnumerable<ArmorEffectDto>>(armor.SpecialEffects);
        diagnosticContext.Set("ArmorEffects", results);

        return results;
    }
}