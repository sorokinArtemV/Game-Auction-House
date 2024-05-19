namespace ItemsService.ItemServiceCore.Entities.ItemTypes;

public class Armor : BaseItem
{
    public int Id { get; set; }
    public string? ArmorType { get; set; }
    public int ArmorValue { get; set; }
}