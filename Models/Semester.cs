namespace Schedule.Models;

public partial class Semester
{
    public int Idsemester { get; set; }

    public int? Year { get; set; }

    public byte? EvenOdd { get; set; }

    public virtual ICollection<Week> Weeks { get; set; } = new List<Week>();
}
