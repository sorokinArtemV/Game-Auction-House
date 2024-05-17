using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Weapons;
using ItemsService.ItemsServiceApplication.Weapons.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController(IWeaponsService weaponsService) : ControllerBase
{
    [HttpGet("weapons")]
    public async Task<ActionResult<IEnumerable<Weapon>>> GetAllWeapons()
    {
        var weapons = await weaponsService.GetAllAsync();

        return Ok(weapons);
    }

    [HttpGet("weapons/{id}")]
    public async Task<ActionResult<Weapon>> GetWeaponById(int id)
    {
        var weapon = await weaponsService.GetByIdAsync(id);

        if (weapon is null) return NotFound();

        return Ok(weapon);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeapon(CreateWeaponDto createWeaponDto)
    {
        var id = await weaponsService.CreateAsync(createWeaponDto);

        return CreatedAtAction(nameof(GetWeaponById), new { id }, null);
    }
}