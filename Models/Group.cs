namespace Schedule.Models;

public partial class Group
{
    public int Idgroup { get; set; }

    public string? GroupNumber { get; set; }

    public string? ShortNumber { get; set; }

    public int? StudentAmmount { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
