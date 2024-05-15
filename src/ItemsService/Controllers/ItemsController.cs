using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ItemsDbContext _context;

    public ItemsController(ItemsDbContext context)
    {
        _context = context;
    }

    [HttpGet("weapons")]
    public async Task<ActionResult<IEnumerable<Weapon>>> GetWeapons()
    {
        return await _context.Weapons
            .Include(w => w.SpecialEffects)
            .ToListAsync();
    }
    
    [HttpGet("armor")]
    public async Task<ActionResult<IEnumerable<Armor>>> GetArmor()
    {
        return await _context.Armor
            .Include(w => w.SpecialEffects)
            .ToListAsync();
    }
}