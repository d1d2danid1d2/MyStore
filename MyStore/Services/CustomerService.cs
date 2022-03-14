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

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAll();
        CustomerModel GetById(int id);
        public IEnumerable<Customer> GetInfoById(int id);
        CustomerModel AddCustomer(CustomerModel newCustomer);
        bool Exists(int id);
        void Update(CustomerModel model);
        bool Delete(int id);       
    }
    public class CustomerService : ICustomerService
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

        public IEnumerable<Customer> GetInfoById(int id)
        {
            var allCustomers = customerRepository.GetInfoById(id).ToList();
            return allCustomers;
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

        public bool Exists(int id)
        {
            return customerRepository.Exists(id);
        }
        public void Update(CustomerModel model)
        {
            Customer customerToUpdate = mapper.Map<Customer>(model);
            customerRepository.Update(customerToUpdate);
        }
        public bool Delete(int id)
        {
            var customerToDelete = customerRepository.GetById(id);
            customerRepository.Delete(customerToDelete);
            return customerToDelete != null;
        }

    }
}
