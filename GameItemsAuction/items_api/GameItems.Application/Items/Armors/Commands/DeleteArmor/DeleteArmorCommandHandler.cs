using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Items.Armors.Commands.DeleteArmor;

public class DeleteArmorCommandHandler(
    ILogger<DeleteArmorCommandHandler> logger,
    IGenericItemsRepository<Armor> itemsRepository,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<DeleteArmorCommand>
{
    public async Task Handle(DeleteArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting armor with id {Id}", request.Id);

        var armor = await itemsRepository.GetByIdAsync(request.Id);
        if (armor == null) throw new NotFoundException(nameof(Armor), request.Id.ToString());

        await itemsRepository.DeleteAsync(armor);

        diagnosticContext.Set("Armor deleted", armor);
    }
}