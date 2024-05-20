using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.CreateWeaponEffect;
using ItemsService.ItemsServiceApplication.WeaponEffects.Dto;
using ItemsService.ItemsServiceApplication.WeaponEffects.Queries.GetAllWeaponEffects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/items/weapons/{weaponId}/effects")]
[ApiController]
public class WeaponEffectsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeaponEffectDto>>> GetAllWeaponEffects([FromRoute] int weaponId)
    {
      var effects = await mediator.Send(new GetAllWeaponEffectsQuery(weaponId));
      
      return Ok(effects);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<WeaponEffectDto>> GetWeaponEffectById([FromRoute] int weaponId, [FromRoute] int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateWeaponEffect([FromRoute] int weaponId, CreateWeaponEffectCommand command)
    {
       command.WeaponId = weaponId;
       
       await mediator.Send(command);
       
       return Created();
    }
}