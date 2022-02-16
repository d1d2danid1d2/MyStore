using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    //What it does
    //The class takes the data from the "CustomerRepository" and stores it in the readonly field "customerRepository"
    
    //The interface asks for the those two methods and the class must implement them 
    // --> CustomerController

    public interface ICustormerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);


    }
    public class CustomerService : ICustormerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);
        }
    }
}
