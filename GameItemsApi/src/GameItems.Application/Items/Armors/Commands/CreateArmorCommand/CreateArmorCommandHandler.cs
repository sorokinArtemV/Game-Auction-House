using AutoMapper;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.RepositoryContracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameItems.Application.Items.Armors.Commands.CreateArmorCommand;

public class CreateArmorCommandHandler(
    ILogger<CreateArmorCommandHandler> logger,
    IGenericItemsRepository<Armor> itemsRepository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
) : IRequestHandler<CreateArmorCommand, int>
{
    public Task<int> Handle(CreateArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating armor");

        var armor = mapper.Map<Armor>(request);

        var id = itemsRepository.CreateAsync(armor);

        diagnosticContext.Set("Armor created", armor);

        return id;
    }
}