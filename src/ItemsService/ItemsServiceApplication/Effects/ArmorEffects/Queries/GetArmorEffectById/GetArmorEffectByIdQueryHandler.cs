using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Dto;
using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Queries.GetAllArmorEffects;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Queries.GetArmorEffectById;

public class GetArmorEffectByIdQueryHandler(
    ILogger<GetAllArmorEffectsQueryHandler> logger,
    IGenericItemsRepository<Armor> armorRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext

    ) : IRequestHandler<GetArmorEffectByIdQuery, ArmorEffectDto>
{
    public async Task<ArmorEffectDto> Handle(GetArmorEffectByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapon effects for weapon {ArmorId}", request.ArmorId);
        
        var armor = await armorRepository.GetByIdAsync(request.ArmorId);
        
        if (armor is null) throw new NotFoundException(nameof(Armor), request.ArmorId.ToString());
        
        var effect = armor.SpecialEffects.FirstOrDefault(x => x.Id == request.EffectId);
        
        if (effect is null) throw new NotFoundException(nameof(Armor), request.ArmorId.ToString());
        
        var results = mapper.Map<ArmorEffectDto>(effect);
        
        diagnosticContext.Set("ArmorEffects", results);
        
        return results;
    }
}