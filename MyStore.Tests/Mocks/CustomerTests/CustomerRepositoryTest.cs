using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Tests.Mock.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.Mock.Repository
{
    public class CustomerRepositoryTest : Mock<ICustomersRepository>
    {
        private Mock<ICustomersRepository> mockRepo = new Mock<ICustomersRepository>();
        public static int cId = 2;

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
        [Fact]
        public void ShouldReturn_OkOnGetById()
        {
            //arrange
            var user = ReturnMultiple()[0];
            //act
            mockRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(ReturnMultiple()[0]);

            var actualCustomer = mockRepo.Object.GetById(1);

            Assert.Equal(user.Custid, actualCustomer.Custid);
            Assert.IsType<Customer>(actualCustomer);
        }

        [Fact]
        public void ShouldReturn_OKOnTest()
        {
            var user = ReturnMultiple()[0];
            var list = new List<Customer> { user };
            var users = new Mock<ICustomersRepository>();
            users.Setup(x => x.GetById(It.IsAny<int>())).Returns(ReturnMultiple()[0]);

            var actualCustomer = users.Object.GetById(1);

            Assert.Equal(user.Custid, actualCustomer.Custid);
            Assert.IsType<Customer>(actualCustomer);

        }

        [Fact]
        public void ShouldReturnTrue_WhenYouAddANewCustomer()
        {
            mockRepo.Setup(x => x.Add(It.IsAny<Customer>())).Returns(ReturnsSingle());

            var customers = mockRepo.Object.Add(ReturnsSingle());

            Assert.IsType<Customer>(customers);
            Assert.Equal(cId, customers.Custid);
        }

        [Fact]
        public void ShouldReturnTrue_WhenYouUpdateACustomer()
        {
            mockRepo.Setup(x => x.Update(It.IsAny<Customer>())).Verifiable();
        }

        [Fact]
        public void ShouldReturnTrue_WhenYouDeleteCustomer()
        {
            //arrange
            var list = ReturnMultipleForUpdate();
            var context = new Mock<StoreContext>();
            ICustomersRepository customerRepo = new CustomersRepository(context.Object);
            //act
            context.Setup(x => x.Customers.Remove(It.IsAny<Customer>()))
            .Callback<Customer>((entity) => list.Remove(entity));
            
            customerRepo.Delete(list[0]);

            //assert
            Assert.Equal(1, list.Count());
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
        private static Customer ReturnsSingle()
        {
            return new Customer
            {
                Custid = cId,
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
            };
        }
        private List<Customer> ReturnMultipleForUpdate()
        {
            return new List<Customer>()
            {
                new Customer
                {
                    Custid = 1,
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
                    Custid = 2,
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
