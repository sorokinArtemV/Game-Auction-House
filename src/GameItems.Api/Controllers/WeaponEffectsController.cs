using GameItems.Application.Effects.WeaponEffects.Commands.CreateWeaponEffect;
using GameItems.Application.Effects.WeaponEffects.Commands.DeleteAllWeaponEffects;
using GameItems.Application.Effects.WeaponEffects.Commands.DeleteWeaponEffect;
using GameItems.Application.Effects.WeaponEffects.Dto;
using GameItems.Application.Effects.WeaponEffects.Queries.GetAllWeaponEffects;
using GameItems.Application.Effects.WeaponEffects.Queries.GetWeaponEffectById;
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

        var effectId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetWeaponEffectById), new { weaponId, effectId }, null);
    }

    [HttpDelete("{effectId}")]
    public async Task<IActionResult> DeleteWeaponEffect(int weaponId, int effectId)
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