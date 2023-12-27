namespace Schedule.Models;

public partial class LessonNumber
{
    public int IdlessonNumber { get; set; }

    public int? LessonNumber1 { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
