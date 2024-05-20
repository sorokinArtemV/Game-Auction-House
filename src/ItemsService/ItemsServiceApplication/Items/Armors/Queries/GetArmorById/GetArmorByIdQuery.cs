using ItemsService.ItemsServiceApplication.Items.Armors.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Items.Armors.Queries.GetArmorById;

public class GetArmorByIdQuery(int id) : IRequest<ArmorDto>
{
    public int Id { get; set; } = id;
}