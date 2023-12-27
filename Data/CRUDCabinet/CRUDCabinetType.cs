using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDCabinetType
    {
        public static ObservableCollection<CabinetType> ReadCabinetType()
        {
            using SheduleDbContext context = new();
            ObservableCollection<CabinetType> cabinet = new([.. context.CabinetTypes]);
            return cabinet;
        }

        public bool CreateCabinetType(string cabinetName, string discription)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    CabinetType newCabinetType = new()
                    {
                        CabinetName = cabinetName,
                        Discription = discription,
                    };
                    _ = context.CabinetTypes.Add(newCabinetType);
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

        public bool UpdateCabinetType(CabinetType newCabinetType)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    CabinetType? oldCabinetType = context.CabinetTypes.FirstOrDefault(id => id.IdcabinetType == newCabinetType.IdcabinetType);
                    if (oldCabinetType != null)
                    {
                        oldCabinetType.CabinetName = newCabinetType.CabinetName;
                        oldCabinetType.Discription = newCabinetType.Discription;
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

        public bool DeleteCabinetType(CabinetType deleteCabinetType)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.CabinetTypes.Remove(deleteCabinetType);
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