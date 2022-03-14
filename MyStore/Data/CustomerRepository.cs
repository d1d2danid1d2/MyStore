using Microsoft.EntityFrameworkCore;
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
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        IQueryable<Customer> GetInfoById(int id);
        Customer Add(Customer customerToAdd);
        bool Exists(int id);
        bool Delete(Customer customerToDelete);         
        void Update(Customer customerToUpdate);
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
        public IQueryable<Customer> GetInfoById(int id)
        {
            return context.Customers.Include(x => x.Orders).Select(x => x).Where(x => x.Custid == id);                      
        }   
        public Customer Add(Customer customerToAdd)
        {
            var addedCustomer = context.Add(customerToAdd);
            context.SaveChanges();
            return addedCustomer.Entity;
        }
        public bool Exists(int id)
        {
            var exist = context.Customers.Count(x => x.Custid == id);
            return exist == 1;
        }
        public void Update(Customer customerToUpdate)
        {
            context.Customers.Update(customerToUpdate);
            context.SaveChanges();
        }
        public bool Delete(Customer customerToDelete)
        {
            var deleteCustomer = context.Customers.Remove(customerToDelete);
            context.SaveChanges();
            return deleteCustomer != null;
        }
    }
}
