using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Add(Customer toAdd);
        bool Exists(int id);
        void Update(Customer toUpdate);
        bool Delete(int id);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository repository;

        public CustomerService(ICustomersRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Customer> GetAll()
        {
            return repository.GetAll();
        }
        public Customer GetById(int id)
        {
            return repository.GetById(id);
        }
        public Customer Add(Customer toAdd)
        {
            return repository.Add(toAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Customer toUpdate)
        {
            repository.Update(toUpdate);
        }
        public bool Delete(int id)
        {
            var deleteItem = repository.GetById(id);
            return repository.Delete(deleteItem);
        }
    }
}
