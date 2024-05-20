using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ItemsService.ItemServiceCore.RepositoryContracts;
using Swashbuckle.AspNetCore.Annotations;

namespace ItemsService.ItemServiceCore.Entities.ItemParameters;

public abstract class BaseEffect : IGenericRepositoryUsable
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Charges { get; set; }

    [SwaggerSchema(ReadOnly = true)] public TimeSpan Duration { get; set; }
    public bool IsPassive { get; set; }
}