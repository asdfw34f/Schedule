namespace Schedule.Models;

public partial class Teacher
{
    public int Idteacher { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? MiddleName { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
