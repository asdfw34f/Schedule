namespace Schedule.Models;

public partial class CabinetType
{
    public int IdcabinetType { get; set; }

    public string? CabinetName { get; set; }

    public string? Discription { get; set; }

    public virtual Cabinet? Cabinet { get; set; }
}
