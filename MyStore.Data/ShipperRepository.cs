using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IShipperRepository
    {
        IEnumerable<Shipper> GetAll();
        Shipper GetById(int id);
        Shipper Add(Shipper add);
        bool Exists(int id);
        void Update(Shipper toUpdate);
        bool Delete(Shipper toDelete);
    }
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreContext context;

        public ShipperRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Shipper> GetAll()
        {
            return context.Shippers.ToList();
        }
        public Shipper GetById(int id)
        {
            return context.Shippers.Find(id);
        }
        public Shipper Add(Shipper add)
        {
            var addedShipper = context.Shippers.Add(add);
            context.SaveChanges();
            return addedShipper.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Shippers.Count(x => x.Shipperid == id);
            return exists == 1;
        }
        public void Update(Shipper toUpdate)
        {
            context.Shippers.Update(toUpdate);
            context.SaveChanges();
        }
        public bool Delete(Shipper toDelete)
        {
            var deleted = context.Shippers.Remove(toDelete);
            context.SaveChanges();
            return deleted != null;
        }
    }
}
