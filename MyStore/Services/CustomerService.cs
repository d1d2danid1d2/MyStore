using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
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
        CustomerModel AddCustomer(CustomerModel newCustomer);
        IEnumerable<CustomerModel> GetAll();
        CustomerModel GetById(int id);


    }
    public class CustomerService : ICustormerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            var allCustomers = customerRepository.GetAll().ToList();
            return mapper.Map<IEnumerable<CustomerModel>>(allCustomers);
        }

        public CustomerModel GetById(int id)
        {
            var findCustomer = customerRepository.GetById(id);
            return mapper.Map<CustomerModel>(findCustomer);
        }

        public CustomerModel AddCustomer(CustomerModel newCustomer)
        {
            Customer customerToAdd = mapper.Map<Customer>(newCustomer);
            var addedCustomer = customerRepository.Add(customerToAdd);

            return mapper.Map<CustomerModel>(addedCustomer);
        }
    }
}
