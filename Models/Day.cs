namespace Schedule.Models;

public partial class Day
{
    public int Idday { get; set; }

    public int? Idweek { get; set; }

    public int? Idweekday { get; set; }

    public DateOnly? DateDay { get; set; }

    public virtual Week? IdweekNavigation { get; set; }

    public virtual Weekday? IdweekdayNavigation { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
