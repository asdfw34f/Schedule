using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDLessonNumber
    {
        public ObservableCollection<LessonNumber> ReadLessonNumber()
        {
            using SheduleDbContext context = new();
            ObservableCollection<LessonNumber> LessonNumber = new([.. context.LessonNumbers]);
            return LessonNumber;
        }

        public bool CreateLessonNumber(int LessonNumber1)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    LessonNumber newLessonNumber = new()
                    {
                        LessonNumber1 = LessonNumber1,
                    };
                    _ = context.LessonNumbers.Add(newLessonNumber);
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

        public bool UpdateLessonNumber(LessonNumber newLessonNumber)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    LessonNumber? oldLessonNumber = context.LessonNumbers.FirstOrDefault(id => id.IdlessonNumber == newLessonNumber.IdlessonNumber);
                    if (oldLessonNumber != null)
                    {
                        oldLessonNumber.LessonNumber1 = newLessonNumber.LessonNumber1;
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

        public bool DeleteLessonNumber(LessonNumber deleteLessonNumber)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.LessonNumbers.Remove(deleteLessonNumber);
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