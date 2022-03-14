using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Tests.Mocks.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.Mocks.Repository
{
    public class CustomerRepositoryTest
    {
        private Mock<ICustomerRepository> mockRepo;

        public CustomerRepositoryTest()
        {
            mockRepo = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void Should_GetAllCustomers()
        {
            //arrange
            mockRepo.Setup(x => x.GetAll()).Returns(ReturnMultiple);

            //act 

            var returns = mockRepo.Object.GetAll();

            //assert
            Assert.Equal(2, returns.Count());
            Assert.IsType<List<Customer>>(returns);

        }



        public List<Customer> ReturnMultiple()
        {
            return new List<Customer>()
            {
                new Customer
                {
                    Custid = CustomerConsts.Custid,
                    Companyname = CustomerConsts.Companyname,
                    Contactname = CustomerConsts.Contactname,
                    Contacttitle = CustomerConsts.Contacttitle,
                    Country = CustomerConsts.Country,
                    Address = CustomerConsts.Address,
                    City = CustomerConsts.City,
                    Fax = CustomerConsts.Fax,
                    Phone = CustomerConsts.Phone,
                    Postalcode = CustomerConsts.Postalcode,
                    Region = CustomerConsts.Region
                },
                new Customer
                {
                    Custid = CustomerConsts.Custid,
                    Companyname = CustomerConsts.Companyname,
                    Contactname = CustomerConsts.Contactname,
                    Contacttitle = CustomerConsts.Contacttitle,
                    Country = CustomerConsts.Country,
                    Address = CustomerConsts.Address,
                    City = CustomerConsts.City,
                    Fax = CustomerConsts.Fax,
                    Phone = CustomerConsts.Phone,
                    Postalcode = CustomerConsts.Postalcode,
                    Region = CustomerConsts.Region
                }

            };
        }

    }
}
