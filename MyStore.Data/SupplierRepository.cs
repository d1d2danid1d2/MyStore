using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        Supplier Add(Supplier addSupplier);
        bool Exists(int id);
        void Update(Supplier updateSupplier);
        bool Delete(Supplier deleteSupplier);
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
        public Supplier Add(Supplier addSupplier)
        {
            var added = context.Suppliers.Add(addSupplier);
            context.SaveChanges();
            return added.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Suppliers.Count(x => x.Supplierid == id);
            return exists == 1;
        }
        public void Update(Supplier updateSupplier)
        {
            context.Suppliers.Update(updateSupplier);
            context.SaveChanges();
        }
        public bool Delete(Supplier deleteSupplier)
        {
            var deleted = context.Remove(deleteSupplier);
            context.SaveChanges();
            return deleted != null;
        }
    }
}
