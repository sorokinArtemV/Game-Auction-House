using ItemsService.ItemsServiceApplication.Items.Armors.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Items.Armors.Queries.GetAllArmors;

public class GetAllArmorsQuery : IRequest<IEnumerable<ArmorDto>>
{
}