using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Weapons.Commands.DeleteWeapon;

public class DeleteWeaponCommandHandler(
    ILogger<DeleteWeaponCommandHandler> logger,
    IGenericRepository<Weapon> repository,
    IDiagnosticContext  diagnosticContext
) : IRequestHandler<DeleteWeaponCommand, bool>
{
    public async Task<bool> Handle(DeleteWeaponCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting weapon with id {Id}", request.Id);

        var weapon = await repository.GetByIdAsync(request.Id);

        if (weapon is null)
        {
            logger.LogInformation("Weapon with id {Id} not found", request.Id); ;
            return false;
        }

        await repository.DeleteAsync(weapon);
        
        diagnosticContext.Set("Weapon deleted", weapon);

        return true;
    }
}