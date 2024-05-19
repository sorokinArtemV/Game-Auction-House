using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Weapons.Commands.UpdateWeaponCommand;

public class UpdateWeaponCommandHandler(
    ILogger<UpdateWeaponCommandHandler> logger,
    IGenericRepository<Weapon> repository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<UpdateWeaponCommand>
{
    public async Task Handle(UpdateWeaponCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating weapon");

        var weapon = await repository.GetByIdAsync(request.Id);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.Id.ToString());

        mapper.Map(request, weapon);

        await repository.SaveChangesAsync();

        diagnosticContext.Set("Weapon updated", weapon);
    }
}