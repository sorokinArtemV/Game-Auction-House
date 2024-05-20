using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.CreateWeaponEffect;

public class CreateWeaponEffectCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Charges { get; set; }

    [SwaggerSchema(ReadOnly = true)] public TimeSpan Duration { get; set; }
    public bool IsPassive { get; set; }

    public int WeaponId { get; set; }
}