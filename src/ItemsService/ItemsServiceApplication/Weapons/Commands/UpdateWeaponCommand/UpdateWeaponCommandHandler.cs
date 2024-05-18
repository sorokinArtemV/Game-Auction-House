using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Weapons.Commands.UpdateWeaponCommand;

public class UpdateWeaponCommandHandler(
    ILogger<UpdateWeaponCommandHandler> logger,
    IGenericRepository<Weapon> repository,
    IDiagnosticContext  diagnosticContext
) : IRequestHandler<UpdateWeaponCommand, bool>
{
    public async Task<bool> Handle(UpdateWeaponCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating weapon...");

        var weapon = await repository.GetByIdAsync(request.Id);

        if (weapon is null) return false;

        diagnosticContext.Set("Weapon updated", weapon);
        
        return true;
    }
}