using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;
using Day = Schedule.Models.Day;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDDay
    {
        public ObservableCollection<Day> ReadDay()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Day> Day = new([.. context.Days.Include(id => id.IdweekNavigation).Include(id => id.IdweekdayNavigation)]);
            return Day;
        }

        public bool CreateDay(Week week, Weekday weekday, DateOnly date)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Day newDay = new()
                    {
                        Idweek = week.Idweek,
                        Idweekday = weekday.Idweekday,
                        DateDay = date
                    };
                    _ = context.Days.Add(newDay);
                    _ = context.SaveChanges();
                    created = true;
                }
                catch (Exception ex)
                {
                    _ = System.Windows.MessageBox.Show(ex.Message);
                    created = false;
                }
                return created;
            }
        }

        public bool UpdateDay(Day newDay)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Day? oldDay = context.Days.FirstOrDefault(id => id.Idday == newDay.Idday);
                    if (oldDay != null)
                    {
                        oldDay.Idweekday = newDay.Idweekday;
                        oldDay.Idweek = newDay.Idweek;
                        oldDay.DateDay = newDay.DateDay;
                        _ = context.SaveChanges();
                        updated = true;
                    }
                }
                catch (Exception ex)
                {
                    _ = System.Windows.MessageBox.Show(ex.Message);
                    updated = false;
                }
            }
            return updated;
        }

        public bool DeleteDay(Day deleteDay)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Days.Remove(deleteDay);
                    _ = context.SaveChanges();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    _ = System.Windows.MessageBox.Show(ex.Message);
                    deleted = false;
                }
            }
            return deleted;
        }

    }
}