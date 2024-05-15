using System.ComponentModel.DataAnnotations;
using ItemsService.ItemServiceCore.Constants;
using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemServiceCore.Entities.ItemTypes;

public class Weapon : BaseItem
{
    public int Id { get; set; }
    public string? WeaponType { get; set; }
    public string? DamageType { get; set; }
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double AttackSpeed { get; set; }
    public double Dps => (MinDamage + MaxDamage) / 2 / AttackSpeed;
    public bool IsTwoHanded { get; set; }
    public bool IsMainHand { get; set; }
    public bool IsOffHand { get; set; }
}