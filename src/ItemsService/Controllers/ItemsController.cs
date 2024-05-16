using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Weapons;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        
}