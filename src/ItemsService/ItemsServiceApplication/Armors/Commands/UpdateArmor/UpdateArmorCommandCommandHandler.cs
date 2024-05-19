using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.Exceptions;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.UpdateArmor;

public class UpdateArmorCommandCommandHandler(
    ILogger<UpdateArmorCommandCommandHandler> logger,
    IGenericRepository<Armor> repository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<UpdateArmorCommand>
{
    public async Task Handle(UpdateArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating armor");

        var armor = await repository.GetByIdAsync(request.Id);

        if (armor == null) throw new NotFoundException(nameof(Armor), request.Id.ToString());

        mapper.Map(request, armor);

        await repository.SaveChangesAsync();

        diagnosticContext.Set("Armor updated", armor);
    }
}