using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Items.Armors.Commands.CreateArmorCommand;

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