using Microsoft.EntityFrameworkCore;

namespace Schedule.Models;

public partial class SheduleDbContext : DbContext
{
    public SheduleDbContext()
    {
    }

    public SheduleDbContext(DbContextOptions<SheduleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<CabinetType> CabinetTypes { get; set; }

    public virtual DbSet<Day> Days { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonNumber> LessonNumbers { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Week> Weeks { get; set; }

    public virtual DbSet<Weekday> Weekdays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer("Server=DESKTOP-9N46EPK\\DANIIL_BANK1230; Database=SheduleDB; Trusted_Connection=True; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Cabinet>(entity =>
        {
            _ = entity.HasKey(e => e.Idcabinet);

            _ = entity.HasIndex(e => e.CabinetNumber, "UQ_Cabinet_CabinetNumber").IsUnique();

            _ = entity.Property(e => e.Idcabinet)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDCabinet");
            _ = entity.Property(e => e.CabinetNumber).HasMaxLength(20);
            _ = entity.Property(e => e.IdcabinetType).HasColumnName("IDCabinetType");

            _ = entity.HasOne(d => d.IdcabinetNavigation).WithOne(p => p.Cabinet)
                .HasForeignKey<Cabinet>(d => d.Idcabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cabinets_CabinetTypes");
        });

        _ = modelBuilder.Entity<CabinetType>(entity =>
        {
            _ = entity.HasKey(e => e.IdcabinetType);

            _ = entity.Property(e => e.IdcabinetType).HasColumnName("IDCabinetType");
            _ = entity.Property(e => e.CabinetName).HasMaxLength(45);
            _ = entity.Property(e => e.Discription).HasMaxLength(45);
        });

        _ = modelBuilder.Entity<Day>(entity =>
        {
            _ = entity.HasKey(e => e.Idday);

            _ = entity.Property(e => e.Idday).HasColumnName("IDDay");
            _ = entity.Property(e => e.Idweek).HasColumnName("IDWeek");
            _ = entity.Property(e => e.Idweekday).HasColumnName("IDWeekday");

            _ = entity.HasOne(d => d.IdweekNavigation).WithMany(p => p.Days)
                .HasForeignKey(d => d.Idweek)
                .HasConstraintName("FK_Days_Weeks");

            _ = entity.HasOne(d => d.IdweekdayNavigation).WithMany(p => p.Days)
                .HasForeignKey(d => d.Idweekday)
                .HasConstraintName("FK_Days_Weekdays");
        });

        _ = modelBuilder.Entity<Group>(entity =>
        {
            _ = entity.HasKey(e => e.Idgroup).HasName("PK_Group_IDGroup");

            _ = entity.HasIndex(e => e.GroupNumber, "UQ_Group_GroupNumber").IsUnique();

            _ = entity.HasIndex(e => e.ShortNumber, "UQ_Group_ShortNumber").IsUnique();

            _ = entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            _ = entity.Property(e => e.GroupNumber).HasMaxLength(50);
            _ = entity.Property(e => e.ShortNumber).HasMaxLength(50);
        });

        _ = modelBuilder.Entity<Lesson>(entity =>
        {
            _ = entity.HasKey(e => e.Idlesson);

            _ = entity.Property(e => e.Idlesson).HasColumnName("IDLesson");
            _ = entity.Property(e => e.Idcabinet).HasColumnName("IDCabinet");
            _ = entity.Property(e => e.Idday).HasColumnName("IDDay");
            _ = entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            _ = entity.Property(e => e.IdlessonNumber).HasColumnName("IDLessonNumber");
            _ = entity.Property(e => e.Idsubject).HasColumnName("IDSubject");
            _ = entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

            _ = entity.HasOne(d => d.IdcabinetNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idcabinet)
                .HasConstraintName("FK_Lessons_Cabinets");

            _ = entity.HasOne(d => d.IddayNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idday)
                .HasConstraintName("FK_Lessons_Days");

            _ = entity.HasOne(d => d.IdgroupNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idgroup)
                .HasConstraintName("FK_Lessons_Groups");

            _ = entity.HasOne(d => d.IdlessonNumberNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdlessonNumber)
                .HasConstraintName("FK_Lessons_LessonNumbers");

            _ = entity.HasOne(d => d.IdsubjectNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idsubject)
                .HasConstraintName("FK_Lessons_Subjects");

            _ = entity.HasOne(d => d.IdteacherNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idteacher)
                .HasConstraintName("FK_Lessons_Teachers");
        });

        _ = modelBuilder.Entity<LessonNumber>(entity =>
        {
            _ = entity.HasKey(e => e.IdlessonNumber);

            _ = entity.Property(e => e.IdlessonNumber).HasColumnName("IDLessonNumber");
            _ = entity.Property(e => e.LessonNumber1).HasColumnName("LessonNumber");
        });

        _ = modelBuilder.Entity<Semester>(entity =>
        {
            _ = entity.HasKey(e => e.Idsemester);

            _ = entity.Property(e => e.Idsemester).HasColumnName("IDSemester");
        });

        _ = modelBuilder.Entity<Subject>(entity =>
        {
            _ = entity.HasKey(e => e.Idsubject);

            _ = entity.Property(e => e.Idsubject).HasColumnName("IDSubject");
            _ = entity.Property(e => e.SubjectName).HasMaxLength(70);
        });

        _ = modelBuilder.Entity<Teacher>(entity =>
        {
            _ = entity.HasKey(e => e.Idteacher).HasName("PK_Teachers_1");

            _ = entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");
            _ = entity.Property(e => e.MiddleName).HasMaxLength(60);
            _ = entity.Property(e => e.Name).HasMaxLength(30);
            _ = entity.Property(e => e.Surname).HasMaxLength(45);
        });

        _ = modelBuilder.Entity<Week>(entity =>
        {
            _ = entity.HasKey(e => e.Idweek);

            _ = entity.Property(e => e.Idweek).HasColumnName("IDWeek");
            _ = entity.Property(e => e.Idsemester).HasColumnName("IDSemester");

            _ = entity.HasOne(d => d.IdsemesterNavigation).WithMany(p => p.Weeks)
                .HasForeignKey(d => d.Idsemester)
                .HasConstraintName("FK_Weeks_Semesters");
        });

        _ = modelBuilder.Entity<Weekday>(entity =>
        {
            _ = entity.HasKey(e => e.Idweekday);

            _ = entity.Property(e => e.Idweekday).HasColumnName("IDWeekday");
            _ = entity.Property(e => e.NameWeekday).HasMaxLength(11);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
