using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDTeacher
    {
        public ObservableCollection<Teacher> ReadTeacher()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Teacher> teachers = new([.. context.Teachers]);
            return teachers;
        }

        public bool CreateTeacher(string name, string surname, string middlename, bool status)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Teacher newTeacher = new()
                    {
                        Name = name,
                        Surname = surname,
                        MiddleName = middlename,
                        Status = status
                    };
                    _ = context.Teachers.Add(newTeacher);
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

        public bool UpdateTeacher(Teacher newTeacher)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Teacher? oldTeacher = context.Teachers.FirstOrDefault(id => id.Idteacher == newTeacher.Idteacher);
                    if (oldTeacher != null)
                    {
                        oldTeacher.Name = newTeacher.Name;
                        oldTeacher.Surname = newTeacher.Surname;
                        oldTeacher.MiddleName = newTeacher.MiddleName;
                        oldTeacher.Status = newTeacher.Status;
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

        public bool DeleteTeacher(Teacher deleteTeacher)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Teachers.Remove(deleteTeacher);
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