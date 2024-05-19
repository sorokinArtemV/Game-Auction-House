using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.UpdateArmor;

public class UpdateArmorCommandCommandHandler(
    ILogger<UpdateArmorCommandCommandHandler> logger,
    IGenericRepository<Armor> repository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
        ) : IRequestHandler<UpdateArmorCommand, bool>
{
    public async Task<bool> Handle(UpdateArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating armor");
        
        var armor = await repository.GetByIdAsync(request.Id);
        
        if (armor == null) return false;
        
        mapper.Map(request, armor);

        await repository.SaveChangesAsync();
        
        diagnosticContext.Set("Armor updated", armor);
        
       return true;
    }
}