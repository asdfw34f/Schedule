using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDGroup
    {
        public ObservableCollection<Group> ReadGroup()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Group> Group = new([.. context.Groups]);
            return Group;
        }

        public bool CreateGroup(string groupNumber, string shortNumber, int studentAmmount)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Group newGroup = new()
                    {
                        GroupNumber = groupNumber,
                        ShortNumber = shortNumber,
                        StudentAmmount = studentAmmount
                    };
                    _ = context.Groups.Add(newGroup);
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

        public bool UpdateGroup(Group newGroup)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Group? oldGroup = context.Groups.FirstOrDefault(id => id.Idgroup == newGroup.Idgroup);
                    if (oldGroup != null)
                    {
                        oldGroup.GroupNumber = newGroup.GroupNumber;
                        oldGroup.ShortNumber = newGroup.ShortNumber;
                        oldGroup.StudentAmmount = newGroup.StudentAmmount;
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

        public bool DeleteGroup(Group deleteGroup)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Groups.Remove(deleteGroup);
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