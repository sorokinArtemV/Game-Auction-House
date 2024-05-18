using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Weapons;
using ItemsService.ItemsServiceApplication.Weapons.Commands.CreateWeapon;
using ItemsService.ItemsServiceApplication.Weapons.DTO;
using ItemsService.ItemsServiceApplication.Weapons.Queries.GetAllWeapons;
using ItemsService.ItemsServiceApplication.Weapons.Queries.GetWeaponById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController(IMediator mediator) : ControllerBase
{
    [HttpGet("weapons")]
    public async Task<ActionResult<IEnumerable<Weapon>>> GetAllWeapons()
    {
        var weapons = await mediator.Send(new GetAllWeaponsQuery());

        return Ok(weapons);
    }

    [HttpGet("weapons/{id}")]
    public async Task<ActionResult<Weapon>> GetWeaponById(int id)
    {
        var weapon = await mediator.Send(new GetWeaponByIdQuery(id));

        if (weapon is null) return NotFound();

        return Ok(weapon);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeapon(CreateWeaponCommand command)
    {
        var id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetWeaponById), new { id }, null);
    }
}