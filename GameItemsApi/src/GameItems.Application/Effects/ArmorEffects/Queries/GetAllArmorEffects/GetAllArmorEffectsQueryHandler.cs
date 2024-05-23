using AutoMapper;
using GameItems.Application.Effects.ArmorEffects.Dto;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.ArmorEffects.Queries.GetAllArmorEffects;

public class GetAllArmorEffectsQueryHandler(
    ILogger<GetAllArmorEffectsQueryHandler> logger,
    IGenericItemsRepository<Armor> armorRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<GetAllArmorEffectsQuery, IEnumerable<ArmorEffectDto>>
{
    public async Task<IEnumerable<ArmorEffectDto>> Handle(GetAllArmorEffectsQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all weapon effects for weapon {ArmorId}", request.ArmorId);

        var armor = await armorRepository.GetByIdAsync(request.ArmorId);

        if (armor is null) throw new NotFoundException(nameof(Armor), request.ArmorId.ToString());

        var results = mapper.Map<IEnumerable<ArmorEffectDto>>(armor.SpecialEffects);

        diagnosticContext.Set("ArmorEffects", results);

        return results;
    }
}