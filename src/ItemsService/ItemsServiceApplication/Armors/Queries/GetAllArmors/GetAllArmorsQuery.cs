using ItemsService.ItemServiceCore.Entities.ItemTypes;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Armors.Queries.GetAllArmors;

public class GetAllArmorsQuery : IRequest<IEnumerable<Armor>>
{
    
}