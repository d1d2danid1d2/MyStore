using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IShippersRepository
    {
        IEnumerable<Shipper> GetAll();
        Shipper GetById(int id);
        IQueryable<Shipper> GetInfoById(int id);
        Shipper Add(Shipper shipperToAdd);
        bool Exists(int id);
        void Update(Shipper shipperToUpdate);
        bool Delete(Shipper shipperToDelete);
    }
    public class ShippersRepository : IShippersRepository
    {
        private readonly StoreContext context;
        public ShippersRepository(StoreContext context)
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
        public IQueryable<Shipper> GetInfoById(int id)
        {
            return context.Shippers.Include(x => x.Orders).Select(x => x).Where(x => x.Shipperid == id);
        }
        public Shipper Add(Shipper shipperToAdd)
        {
            var addedShipper = context.Add(shipperToAdd);
            context.SaveChanges();
            return addedShipper.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Shippers.Count(x => x.Shipperid == id);
            return exists == 1;
        }
        public void Update(Shipper shipperToUpdate)
        {
            context.Shippers.Update(shipperToUpdate);
            context.SaveChanges();
        }
        public bool Delete(Shipper shipperToDelete)
        {
            var deletedShipper = context.Remove(shipperToDelete);
            context.SaveChanges();
            return deletedShipper != null;
        }
    }
}
