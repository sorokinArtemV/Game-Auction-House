using ItemsService.ItemsServiceApplication.WeaponEffects.Commands.CreateWeaponEffect;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers;

[Route("api/items/weapons/{weaponId}/effects")]
[ApiController]
public class WeaponEffectsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateWeaponEffect([FromRoute] int weaponId, CreateWeaponEffectCommand command)
    {
       command.WeaponId = weaponId;
       
       await mediator.Send(command);
       
       return Created();
    }
}