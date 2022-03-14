using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        IQueryable<Supplier> GetInfoById(int id);
        Supplier Add(Supplier supplierToAdd);
        bool Exists(int id);
        void Update(Supplier supplierToUpdate);
        bool Delete(Supplier supplierToDelete);      
    }

    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext context;
        public SupplierRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }
        public Supplier GetById(int id)
        {
            return context.Suppliers.Find(id);
        }
        public IQueryable<Supplier> GetInfoById(int id)
        {
            var query = context.Suppliers.Include(x => x.Products).Select(x => x);
            query = query.Where(x => x.Supplierid == id);
            return query;
        }
        public Supplier Add(Supplier supplierToAdd)
        {
            var addedSupplier = context.Add(supplierToAdd);
            context.SaveChanges();
            return addedSupplier.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Suppliers.Count(x => x.Supplierid == id);
            return exists == 1;
        }
        public void Update(Supplier supplierToUpdate)
        {
            context.Suppliers.Update(supplierToUpdate);
            context.SaveChanges();
        }
        public bool Delete(Supplier supplierToDelete)
        {
            var deleteSupplier = context.Suppliers.Remove(supplierToDelete);
            context.SaveChanges();
            return deleteSupplier != null;
        }    
    }
}
