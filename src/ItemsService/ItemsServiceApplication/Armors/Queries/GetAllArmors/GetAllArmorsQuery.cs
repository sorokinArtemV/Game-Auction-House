using ItemsService.ItemsServiceApplication.Armors.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Armors.Queries.GetAllArmors;

public class GetAllArmorsQuery : IRequest<IEnumerable<ArmorDto>>
{
}