using AutoMapper;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Items.Weapons.Commands.CreateWeapon;

public class CreateWeaponCommandHandler(
    ILogger<CreateWeaponCommandHandler> logger,
    IGenericItemsRepository<Weapon> weaponsItemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<CreateWeaponCommand, int>
{
    public async Task<int> Handle(CreateWeaponCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating weapon");

        var weapon = mapper.Map<Weapon>(request);

        var id = await weaponsItemsRepository.CreateAsync(weapon);

        diagnosticContext.Set("Weapon created", weapon);

        return id;
    }
}