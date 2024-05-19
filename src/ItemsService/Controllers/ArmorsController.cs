using ItemsService.ItemServiceCore.Entities.ItemTypes;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/items/[controller]")]
[ApiController]
public class ArmorsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Armor>>> GetAllArmors()
    {
        throw new NotImplementedException();
    }
}