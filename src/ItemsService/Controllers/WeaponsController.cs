using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Items.Weapons.Commands.CreateWeapon;
using ItemsService.ItemsServiceApplication.Items.Weapons.Commands.DeleteWeapon;
using ItemsService.ItemsServiceApplication.Items.Weapons.Commands.UpdateWeaponCommand;
using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetAllWeapons;
using ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetWeaponById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/items/[controller]")]
[ApiController]
public class WeaponsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeaponDto>>> GetAllWeapons()
    {
        var weapons = await mediator.Send(new GetAllWeaponsQuery());

        return Ok(weapons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeaponDto>> GetWeaponById(int id)
    {
        var weapon = await mediator.Send(new GetWeaponByIdQuery(id));

        return Ok(weapon);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeapon(CreateWeaponCommand command)
    {
        var id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetWeaponById), new { id }, null);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateWeapon(int id, UpdateWeaponCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWeapon(int id)
    {
        await mediator.Send(new DeleteWeaponCommand(id));

        return NoContent();
    }
}