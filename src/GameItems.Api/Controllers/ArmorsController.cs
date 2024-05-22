using GameItems.Application.Items.Armors.Commands.CreateArmorCommand;
using GameItems.Application.Items.Armors.Commands.DeleteArmor;
using GameItems.Application.Items.Armors.Commands.UpdateArmor;
using GameItems.Application.Items.Armors.DTO;
using GameItems.Application.Items.Armors.Queries.GetAllArmors;
using GameItems.Application.Items.Armors.Queries.GetArmorById;
using GameItems.Core.Entities.ItemTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/items/[controller]")]
[ApiController]
public class ArmorsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArmorDto>>> GetAllWeapons([FromQuery] GetAllArmorsQuery query)
    {
        var weapons = await mediator.Send(query);

        return Ok(weapons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Armor>> GetArmorById(int id)
    {
        var armor = await mediator.Send(new GetArmorByIdQuery(id));

        return Ok(armor);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateArmor(CreateArmorCommand command)
    {
        var id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetArmorById), new { id }, null);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateArmor(int id, UpdateArmorCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteArmor(int id)
    {
        await mediator.Send(new DeleteArmorCommand(id));

        return NoContent();
    }
}