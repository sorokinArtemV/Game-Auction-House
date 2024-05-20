using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.CreateWeaponEffect;
using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.DeleteAllWeaponEffects;
using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.DeleteWeaponEffect;
using ItemsService.ItemsServiceApplication.WeaponEffects.Dto;
using ItemsService.ItemsServiceApplication.WeaponEffects.Queries.GetAllWeaponEffects;
using ItemsService.ItemsServiceApplication.WeaponEffects.Queries.GetWeaponEffectById;
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

    [HttpGet("{effectId}")]
    public async Task<ActionResult<WeaponEffectDto>> GetWeaponEffectById([FromRoute] int weaponId,
        [FromRoute] int effectId)
    {
        var effect = await mediator.Send(new GetWeaponEffectByIdQuery(weaponId, effectId));

        return Ok(effect);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeaponEffect([FromRoute] int weaponId, CreateWeaponEffectCommand command)
    {
        command.WeaponId = weaponId;

        await mediator.Send(command);

        return Created();
    }
    
    [HttpDelete("{effectId}")]
    public async Task<IActionResult> DeleteWeaponEffect([FromRoute] int weaponId, [FromRoute] int effectId)
    {
        await mediator.Send(new DeleteWeaponEffectCommand(weaponId, effectId));
        
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAllWeaponEffects([FromRoute] int weaponId)
    {
        await mediator.Send(new DeleteAllWeaponEffectsCommand(weaponId));
        
        return NoContent();
    }
}