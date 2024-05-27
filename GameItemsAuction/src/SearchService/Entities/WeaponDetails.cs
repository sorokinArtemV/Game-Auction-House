namespace SearchService.Entities;

public class WeaponDetails
{
    public string? WeaponType { get; set; }
    public string? DamageType { get; set; }
    public double MinDamage { get; set; }
    public double? MaxDamage { get; set; }
    public double? AttackSpeed { get; set; }
    public bool? IsTwoHanded { get; set; }

    public bool? IsMainHand { get; set; }
}