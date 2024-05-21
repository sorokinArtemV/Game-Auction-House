using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Items.Armors.Commands.CreateArmorCommand;
using ItemsService.ItemsServiceApplication.Items.Armors.Commands.DeleteArmor;
using ItemsService.ItemsServiceApplication.Items.Armors.Commands.UpdateArmor;
using ItemsService.ItemsServiceApplication.Items.Armors.DTO;
using ItemsService.ItemsServiceApplication.Items.Armors.Queries.GetAllArmors;
using ItemsService.ItemsServiceApplication.Items.Armors.Queries.GetArmorById;
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