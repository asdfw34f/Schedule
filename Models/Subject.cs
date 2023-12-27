namespace Schedule.Models;

public partial class Subject
{
    public int Idsubject { get; set; }

    public string? SubjectName { get; set; }

    public int? SemesterNumber { get; set; }

    public int? LectureHours { get; set; }

    public int? PracticHours { get; set; }

    public int? LabHours { get; set; }

    public int? AttestationHourse { get; set; }

    public int? ConsultationHours { get; set; }

    public int? TotalHours { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
