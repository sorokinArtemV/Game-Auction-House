using ItemsService.ItemsServiceApplication.Armors.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Armors.Queries.GetArmorById;

public class GetArmorByIdQuery(int id) : IRequest<ArmorDto>
{
    public int Id { get; set; } = id;
}