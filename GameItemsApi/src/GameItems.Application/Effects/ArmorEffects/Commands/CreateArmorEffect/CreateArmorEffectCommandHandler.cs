using AutoMapper;
using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Effects.ArmorEffects.Commands.CreateArmorEffect;

public class CreateArmorEffectCommandHandler(
    ILogger<CreateArmorEffectCommandHandler> logger,
    IGenericItemsRepository<Armor> armorItemsRepository,
    IGenericEffectsRepository<ArmorEffect> armorEffectItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<CreateArmorEffectCommand, int>
{
    public async Task<int> Handle(CreateArmorEffectCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating armor effect: {@ArmorEffectRequest}", request);

        var armor = await armorItemsRepository.GetByIdAsync(request.ArmorId);

        if (armor is null) throw new NotFoundException(nameof(Armor), request.ArmorId.ToString());

        var armorEffect = mapper.Map<ArmorEffect>(request);
        diagnosticContext.Set("ArmorEffect created", armorEffect);

        return await armorEffectItemsRepository.CreateAsync(armorEffect);
    }
}