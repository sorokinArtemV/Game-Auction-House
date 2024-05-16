using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    [HttpGet("weapons")]
    public async Task<ActionResult<IEnumerable<Weapon>>> GetAllWeapons()
    {

    }
    
    [HttpGet("armor")]
    public async Task<ActionResult<IEnumerable<Armor>>> GetALlArmor()
    {

    }
}