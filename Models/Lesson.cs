namespace Schedule.Models;

public partial class Lesson
{
    public int Idlesson { get; set; }

    public int? Idday { get; set; }

    public int? IdlessonNumber { get; set; }

    public int? Idcabinet { get; set; }

    public int? Idgroup { get; set; }

    public int? Idsubject { get; set; }

    public int? Idteacher { get; set; }

    public virtual Cabinet? IdcabinetNavigation { get; set; }

    public virtual Day? IddayNavigation { get; set; }

    public virtual Group? IdgroupNavigation { get; set; }

    public virtual LessonNumber? IdlessonNumberNavigation { get; set; }

    public virtual Subject? IdsubjectNavigation { get; set; }

    public virtual Teacher? IdteacherNavigation { get; set; }
}
