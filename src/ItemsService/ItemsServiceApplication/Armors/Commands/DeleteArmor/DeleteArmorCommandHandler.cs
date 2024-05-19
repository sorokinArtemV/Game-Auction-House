using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.DeleteArmor;

public class DeleteArmorCommandHandler(
    ILogger<DeleteArmorCommandHandler> logger,
    IGenericRepository<Armor> repository,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<DeleteArmorCommand>
{
    public async Task Handle(DeleteArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting armor with id {Id}", request.Id);

        var armor = await repository.GetByIdAsync(request.Id);
        if (armor == null) throw new NotFoundException(nameof(Armor), request.Id.ToString());

        await repository.DeleteAsync(armor);

        diagnosticContext.Set("Armor deleted", armor);
    }
}