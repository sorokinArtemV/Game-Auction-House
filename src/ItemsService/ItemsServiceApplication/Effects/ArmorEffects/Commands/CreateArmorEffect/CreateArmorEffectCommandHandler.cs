using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Commands.CreateArmorEffect;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Commands.CreateArmorEffect;

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