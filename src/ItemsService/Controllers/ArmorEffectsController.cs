using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Dto;
using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Queries.GetAllArmorEffects;
using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Queries.GetArmorEffectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/items/armors/{armorId}/effects")]
[ApiController]
public class ArmorEffectsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArmorEffectDto>>> GetArmorEffects(int armorId)
    {
        var effects = await mediator.Send(new GetAllArmorEffectsQuery(armorId));

        return Ok(effects);
    }
    
    [HttpGet("{effectId}")]
    public async Task<ActionResult<ArmorEffectDto>> GetArmorEffectById(int armorId, int effectId)
    {
        var effect = await mediator.Send(new GetArmorEffectByIdQuery(armorId, effectId));
        
        return Ok(effect);
    }
    
    // [HttpPost]
    // public async Task<IActionResult> CreateArmorEffect(int armorId, CreateArmorEffectCommand command)
    // {
    //     command.ArmorId = armorId;
    //    var effect = await mediator.Send(command);
    //
    //    return CreatedAtAction(nameof(GetArmorEffectById), new {armorId, effect.Id}, null);
    // }
    
}