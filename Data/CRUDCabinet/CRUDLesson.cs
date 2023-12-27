using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;
using Day = Schedule.Models.Day;
using MessageBox = System.Windows.MessageBox;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDLesson
    {
        public ObservableCollection<Lesson> ReadLesson()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Lesson> Lesson = new([.. context.Lessons.Include(id => id.IddayNavigation).Include(id => id.IdlessonNumberNavigation).Include(id => id.IdcabinetNavigation)
                .Include(id => id.IdgroupNavigation).Include(id => id.IdsubjectNavigation).Include(id => id.IdteacherNavigation)]);
            return Lesson;
        }

        public bool CreateLesson(Day Idday, LessonNumber IdlessonNumber, Cabinet Idcabinet, Group Idgroup, Subject Idsubject, Teacher Idteacher)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Lesson newLesson = new()
                    {
                        Idday = Idday.Idday,
                        IdlessonNumber = IdlessonNumber.IdlessonNumber,
                        Idcabinet = Idcabinet.Idcabinet,
                        Idgroup = Idgroup.Idgroup,
                        Idsubject = Idsubject.Idsubject,
                        Idteacher = Idteacher.Idteacher
                    };
                    _ = context.Lessons.Add(newLesson);
                    _ = context.SaveChanges();
                    created = true;
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message);
                    created = false;
                }
                return created;
            }
        }

        public bool UpdateLesson(Lesson newLesson)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Lesson? oldLesson = context.Lessons.FirstOrDefault(id => id.Idlesson == newLesson.Idlesson);
                    if (oldLesson != null)
                    {
                        oldLesson.Idday = newLesson.Idday;
                        oldLesson.IdlessonNumber = newLesson.IdlessonNumber;
                        oldLesson.Idcabinet = newLesson.Idcabinet;
                        oldLesson.Idgroup = newLesson.Idgroup;
                        oldLesson.Idsubject = newLesson.Idsubject;
                        oldLesson.Idteacher = newLesson.Idteacher;
                        _ = context.SaveChanges();
                        updated = true;
                    }
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message);
                    updated = false;
                }
            }
            return updated;
        }

        public bool DeleteLesson(Lesson deleteLesson)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Lessons.Remove(deleteLesson);
                    _ = context.SaveChanges();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message);
                    deleted = false;
                }
            }
            return deleted;
        }

    }
}