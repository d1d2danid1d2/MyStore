using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Add(Customer toAdd);
        bool Exists(int id);
        void Update(Customer toUpdate);
        bool Delete(Customer toDelete);
    }
    public class CustomersRepository : ICustomersRepository
    {
        private readonly StoreContext context;

        public CustomersRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }
        public Customer GetById(int id)
        {
            return context.Customers.Find(id);
        }
        public Customer Add(Customer toAdd)
        {
            var added = context.Customers.Add(toAdd);
            context.SaveChanges();
            return added.Entity;
        }
        public bool Exists(int id)
        {
            var count = context.Customers.Count(x => x.Custid == id);
            return count == 1;
        }
        public void Update(Customer toUpdate)
        {
            context.Customers.Update(toUpdate);
            context.SaveChanges();
        }
        public bool Delete(Customer toDelete)
        {
            var deleted = context.Remove(toDelete);
            context.SaveChanges();
            return deleted != null;
        }
    }
}
