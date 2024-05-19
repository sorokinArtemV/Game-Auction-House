using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.DeleteArmor;

public class DeleteArmorCommandHandler(
    ILogger<DeleteArmorCommandHandler> logger,
    IGenericRepository<Armor> repository,
    IDiagnosticContext diagnosticContext
    ) : IRequestHandler<DeleteArmorCommand, bool>
{
    public async Task<bool> Handle(DeleteArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting armor with id {Id}", request.Id);
        
        var armor = await repository.GetByIdAsync(request.Id);
        if (armor == null)
        {
            logger.LogWarning("Armor with id {Id} not found", request.Id);
            return false;
        }
        
        await repository.DeleteAsync(armor);
        
        diagnosticContext.Set("Armor deleted", armor);
        
        return true;
    }
}