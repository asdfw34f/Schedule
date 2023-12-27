using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDWeek
    {
        public ObservableCollection<Week> ReadWeek()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Week> week = new([.. context.Weeks.Include(id => id.IdsemesterNavigation)]);
            return week;
        }

        public bool CreateWeek(Semester semester)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Week newWeek = new()
                    {
                        Idsemester = semester.Idsemester,
                    };
                    _ = context.Weeks.Add(newWeek);
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

        public bool UpdateWeek(Week newweek)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Week? oldWeek = context.Weeks.FirstOrDefault(id => id.Idweek == newweek.Idweek);
                    if (oldWeek != null)
                    {
                        oldWeek.Idsemester = newweek.Idsemester;
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

        public bool DeleteWeek(Week deleteWeek)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Weeks.Remove(deleteWeek);
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