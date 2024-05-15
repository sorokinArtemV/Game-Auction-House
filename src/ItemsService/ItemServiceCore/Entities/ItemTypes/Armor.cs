using System.ComponentModel.DataAnnotations;
using ItemsService.ItemServiceCore.Constants;
using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemServiceCore.Entities.ItemTypes;

public class Armor : BaseItem
{
    public ArmorType ArmorType { get; set; }
    public int ArmorValue { get; set; }
    public bool IsShield { get; set; }
}