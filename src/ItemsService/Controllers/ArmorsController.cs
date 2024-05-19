using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Armors.Commands.CreateArmorCommand;
using ItemsService.ItemsServiceApplication.Armors.Commands.DeleteArmor;
using ItemsService.ItemsServiceApplication.Armors.Commands.UpdateArmor;
using ItemsService.ItemsServiceApplication.Armors.Queries.GetAllArmors;
using ItemsService.ItemsServiceApplication.Armors.Queries.GetArmorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/items/[controller]")]
[ApiController]
public class ArmorsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Armor>>> GetAllArmors()
    {
        var armors = await mediator.Send(new GetAllArmorsQuery());

        return Ok(armors);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Armor>> GetArmorById(int id)
    {
        var armor = await mediator.Send(new GetArmorByIdQuery(id));
        
        if (armor is null) return NotFound();
        
        return Ok(armor);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> CreateArmor(CreateArmorCommand command)
    {
        var id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetArmorById), new { id }, null);
    }
    
    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateArmor(int id, UpdateArmorCommand command)
    {
        command.Id = id;
        var isUpdated = await mediator.Send(command);
        
        if(!isUpdated) return NotFound();
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteArmor(int id)
    {
        var isDeleted = await mediator.Send(new DeleteArmorCommand(id));
        
        if(!isDeleted) return NotFound();
        
        return NoContent();
    }
}