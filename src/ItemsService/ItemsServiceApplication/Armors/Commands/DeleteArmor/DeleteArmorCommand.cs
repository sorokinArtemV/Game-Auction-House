using MediatR;

namespace ItemsService.ItemsServiceApplication.Armors.Commands.DeleteArmor;

public class DeleteArmorCommand(int id) : IRequest<bool>
{
    public int Id { get; set; } = id;
}