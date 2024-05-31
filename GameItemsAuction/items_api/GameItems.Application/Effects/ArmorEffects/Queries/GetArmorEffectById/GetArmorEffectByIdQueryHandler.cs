using AutoMapper;
using GameItems.Application.Effects.ArmorEffects.Dto;
using GameItems.Application.Effects.ArmorEffects.Queries.GetAllArmorEffects;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.ArmorEffects.Queries.GetArmorEffectById;

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