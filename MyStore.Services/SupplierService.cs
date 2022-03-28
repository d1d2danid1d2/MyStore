using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        Supplier Add(Supplier supplierAdd);
        bool Exists(int id);
        void Update(Supplier supplierUpdate);
        bool Delete(int id);
    }
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository repository;

        public SupplierService(ISupplierRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Supplier> GetAll()
        {
            return repository.GetAll();
        }
        public Supplier GetById(int id)
        {
            return repository.GetById(id);
        }
        public Supplier Add(Supplier supplierAdd)
        {
            return repository.Add(supplierAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Supplier supplierUpdate)
        {
            repository.Update(supplierUpdate);
        }
        public bool Delete(int id)
        {
            var supplier = GetById(id);
            return repository.Delete(supplier);
        }
    }
}
