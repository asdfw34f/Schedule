using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDWeekday
    {
        public ObservableCollection<Weekday> ReadWeekday()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Weekday> weekdays = new([.. context.Weekdays]);
            return weekdays;
        }

        public bool CreateWeekday(string nameweekday)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Weekday newWeekday = new()
                    {
                        NameWeekday = nameweekday
                    };
                    _ = context.Weekdays.Add(newWeekday);
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

        public bool UpdateWeekday(Weekday newweekday)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Weekday? oldWeekday = context.Weekdays.FirstOrDefault(id => id.Idweekday == newweekday.Idweekday);
                    if (oldWeekday != null)
                    {
                        oldWeekday.NameWeekday = newweekday.NameWeekday;
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

        public bool DeleteWeekday(Weekday deleteWeekday)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Weekdays.Remove(deleteWeekday);
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