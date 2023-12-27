using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDSemester
    {
        public ObservableCollection<Semester> ReadSemester()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Semester> Semester = new([.. context.Semesters]);
            return Semester;
        }

        public bool CreateSemester(int Year, byte EvenOdd)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Semester newSemester = new()
                    {
                        Year = Year,
                        EvenOdd = EvenOdd
                    };
                    _ = context.Semesters.Add(newSemester);
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

        public bool UpdateSemester(Semester newSemester)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Semester? oldSemester = context.Semesters.FirstOrDefault(id => id.Idsemester == newSemester.Idsemester);
                    if (oldSemester != null)
                    {
                        oldSemester.Year = newSemester.Year;
                        oldSemester.EvenOdd = newSemester.EvenOdd;
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

        public bool DeleteSemester(Semester deleteSemester)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Semesters.Remove(deleteSemester);
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