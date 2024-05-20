using MediatR;

namespace ItemsService.ItemsServiceApplication.Items.Armors.Commands.DeleteArmor;

public class DeleteArmorCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}