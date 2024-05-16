using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ItemsService.ItemServiceCore.Entities.ItemParameters;

public class PrimaryStats
{
    public int? Strength { get; set; }
    public int? Agility { get; set; }
    public int? Stamina { get; set; }
    public int? Intellect { get; set; }
    public int? Spirit { get; set; }
}
