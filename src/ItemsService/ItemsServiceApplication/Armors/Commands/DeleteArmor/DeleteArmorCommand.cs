using MediatR;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.DeleteArmor;

public class DeleteArmorCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}