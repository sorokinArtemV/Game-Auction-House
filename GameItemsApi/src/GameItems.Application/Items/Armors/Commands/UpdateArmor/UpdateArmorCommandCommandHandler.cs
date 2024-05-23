using AutoMapper;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Items.Armors.Commands.UpdateArmor;

public class UpdateArmorCommandCommandHandler(
    ILogger<UpdateArmorCommandCommandHandler> logger,
    IGenericItemsRepository<Armor> itemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<UpdateArmorCommand>
{
    public async Task Handle(UpdateArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating armor");

        var armor = await itemsRepository.GetByIdAsync(request.Id);

        if (armor == null) throw new NotFoundException(nameof(Armor), request.Id.ToString());

        mapper.Map(request, armor);

        await itemsRepository.SaveChangesAsync();

        diagnosticContext.Set("Armor updated", armor);
    }
}