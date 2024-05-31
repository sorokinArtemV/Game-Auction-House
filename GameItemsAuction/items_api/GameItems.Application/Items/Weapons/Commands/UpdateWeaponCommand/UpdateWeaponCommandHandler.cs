using AutoMapper;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.Exceptions;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Items.Weapons.Commands.UpdateWeaponCommand;

public class UpdateWeaponCommandHandler(
    ILogger<UpdateWeaponCommandHandler> logger,
    IGenericItemsRepository<Weapon> itemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<UpdateWeaponCommand>
{
    public async Task Handle(UpdateWeaponCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating weapon");

        var weapon = await itemsRepository.GetByIdAsync(request.Id);

        if (weapon is null) throw new NotFoundException(nameof(Weapon), request.Id.ToString());

        mapper.Map(request, weapon);

        await itemsRepository.SaveChangesAsync();

        diagnosticContext.Set("Weapon updated", weapon);
    }
}