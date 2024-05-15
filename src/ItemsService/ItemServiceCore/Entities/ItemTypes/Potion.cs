using System.ComponentModel.DataAnnotations;
using ItemsService.ItemServiceCore.Constants;
using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemServiceCore.Entities.ItemTypes;

public class Potion : BaseItem
{
    [EnumDataType(typeof(ConsumableType))]
    public ConsumableType ConsumableType { get; set; }
    
    public int Potency { get; set; }
    
    public double Duration { get; set; }
    
    public string? Effect { get; set; }
    
    public Requirement Requirements { get; set; } // Assuming Requirement is an owned type
}