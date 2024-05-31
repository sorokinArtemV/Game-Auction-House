using GameItems.Application.Items.Armors.DTO;
using MediatR;

namespace GameItems.Application.Items.Armors.Queries.GetArmorById;

public class GetArmorByIdQuery(int id) : IRequest<ArmorDto>
{
    public int Id { get; set; } = id;
}