using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace Schedule.Data.CRUDCabinet
{
    internal class CRUDCabinet
    {
        public ObservableCollection<Cabinet> ReadCabinet()
        {
            using SheduleDbContext context = new();
            ObservableCollection<Cabinet> cabinet = new([.. context.Cabinets.Include(u => u.IdcabinetNavigation)]);
            return cabinet;
        }

        public bool CreateCabinet(CabinetType cabinetType, int ammountPlaces, string cabinetNumber)
        {
            {
                bool created = false;
                try
                {
                    using SheduleDbContext context = new();
                    Cabinet newCabinet = new()
                    {
                        IdcabinetType = cabinetType.IdcabinetType,
                        AmmountPlaces = ammountPlaces,
                        CabinetNumber = cabinetNumber
                    };
                    _ = context.Cabinets.Add(newCabinet);
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

        public bool UpdateCabinet(Cabinet newCabinet)
        {
            bool updated = false;
            using (SheduleDbContext context = new())
            {
                try
                {

                    Cabinet? oldCabinet = context.Cabinets.FirstOrDefault(id => id.Idcabinet == newCabinet.Idcabinet);
                    if (oldCabinet != null)
                    {
                        oldCabinet.IdcabinetType = newCabinet.IdcabinetType;
                        oldCabinet.AmmountPlaces = newCabinet.AmmountPlaces;
                        oldCabinet.CabinetNumber = newCabinet.CabinetNumber;
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

        public bool DeleteCabinet(Cabinet deleteCabinet)
        {
            bool deleted = false;
            using (SheduleDbContext context = new())
            {
                try
                {
                    _ = context.Cabinets.Remove(deleteCabinet);
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