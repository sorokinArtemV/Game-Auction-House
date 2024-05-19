namespace ItemsService.ItemServiceCore.Entities.ItemParameters;

public class WeaponEffect : BaseEffect
{
    // [JsonIgnore]
    public int Id { get; set; }
    public int? WeaponId { get; set; }
}