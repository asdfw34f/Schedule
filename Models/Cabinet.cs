namespace Schedule.Models;

public partial class Cabinet
{
    public int Idcabinet { get; set; }

    public int? IdcabinetType { get; set; }

    public int? AmmountPlaces { get; set; }

    public string? CabinetNumber { get; set; }

    public virtual CabinetType IdcabinetNavigation { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
