using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        Supplier Add(Supplier newSupplier);
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
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

        public Supplier Add(Supplier newSupplier)
        {
            var addedSupplier = context.Add(newSupplier);
            context.SaveChanges();
            return addedSupplier.Entity;
        }
    }
}
