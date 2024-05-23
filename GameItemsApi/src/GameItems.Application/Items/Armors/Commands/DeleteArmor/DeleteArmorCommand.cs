using MediatR;

namespace GameItems.Application.Items.Armors.Commands.DeleteArmor;

public class DeleteArmorCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}