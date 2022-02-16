using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    //What it does
    //This repository takes the data from the data base and stores it in a readonly field "context"

    //the interface is the base and the class is the child of it
    //the interface asks for the two methods and the class must implement it
    // --> CustomerService

    public interface ICustomerRepository
    {
        Customer Add(Customer newCustomer);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext context;

        public CustomerRepository(StoreContext context)
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
        
        public Customer Add(Customer newCustomer)
        {
            var addedCustomer = context.Add(newCustomer);
            context.SaveChanges();
            return addedCustomer.Entity;
        }
    }
}
