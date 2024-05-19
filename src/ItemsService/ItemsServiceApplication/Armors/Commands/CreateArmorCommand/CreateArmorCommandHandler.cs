using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using MediatR;
using Serilog;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.CreateArmorCommand;

public class CreateArmorCommandHandler(
    ILogger<CreateArmorCommandHandler> logger,
    IGenericRepository<Armor> repository,
    IMapper mapper,
    IDiagnosticContext diagnosticContext
    ) : IRequestHandler<CreateArmorCommand, int>
{
    public Task<int> Handle(CreateArmorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating armor");
        
        var armor = mapper.Map<Armor>(request);
        
        var id = repository.CreateAsync(armor);
        
        diagnosticContext.Set("Armor created", armor);
        
        return id;
    }
}