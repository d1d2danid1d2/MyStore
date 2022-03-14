using Moq;
using MyStore.Data;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Mocks.Services
{
    public class MockCustomerService : Mock<ICustomerService>
    {
        public MockCustomerService MockGetAllCustomers(List<CustomerModel> result)
        {
            Setup(x => x.GetAll()).Returns(result);
            return this;
        }
        
        public MockCustomerService MockById(CustomerModel customer)
        {
            Setup(x => x.GetById(It.IsAny<int>())).Returns(customer);
            return this;
        }

    }
}
