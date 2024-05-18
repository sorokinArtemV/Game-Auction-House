using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Weapons.Commands.DeleteWeapon;

public class DeleteWeaponCommandHandler(
    ILogger<DeleteWeaponCommand> logger,
    IGenericRepository<Weapon> repository,
    IDiagnosticContext  diagnosticContext
) : IRequestHandler<DeleteWeaponCommand, bool>
{
    public async Task<bool> Handle(DeleteWeaponCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting weapon {request.Id}");

        var weapon = await repository.GetByIdAsync(request.Id);

        if (weapon is null) return false;

        await repository.SaveChangesAsync();
        
        diagnosticContext.Set("Weapon deleted", weapon);

        return true;
    }
}