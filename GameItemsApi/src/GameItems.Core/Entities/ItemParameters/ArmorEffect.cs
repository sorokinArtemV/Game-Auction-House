namespace GameItems.Core.Entities.ItemParameters;

public class ArmorEffect : BaseEffect
{
    public int? ArmorId { get; set; }

    // [JsonIgnore]
    public int Id { get; set; }
}