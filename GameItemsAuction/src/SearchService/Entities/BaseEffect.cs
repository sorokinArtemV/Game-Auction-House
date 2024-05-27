namespace SearchService.Entities;

public class BaseEffect
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Charges { get; set; }

    public TimeSpan Duration { get; set; }
    public bool IsPassive { get; set; }
}