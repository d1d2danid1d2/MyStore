using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyStore.Controllers;
using MyStore.DataPresentation;
using MyStore.Domain.Entities;
using MyStore.Models.Customer;
using MyStore.Services;
using MyStore.Tests.Mock.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.Mock.CustomerTests
{
    public class CustomerControllerTest
    {
        private readonly Mock<ICustomerPresentation> mockCustomerPresentation = new Mock<ICustomerPresentation>();
        private readonly CustomerController controller;

        public CustomerControllerTest()
        {
            controller = new CustomerController(mockCustomerPresentation.Object);
            
        }
        [Fact]
        public void Should_ReturnOkOn_Get()
        {
            //arrange
            mockCustomerPresentation.Setup(x => x.GetAll()).Returns(ReturnMultiple);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<CustomerModelPresentation>;

            //assert

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CustomerModelPresentation>>(actualData);
        }
        [Fact]
        public void Should_ReturnOkOn_GetById()
        {
            // why it failed
            // i have an Exist method and it checks if the customer exists or not
            // and i need to modify for it to work or make it work somehow else
            //arrange
            int id = 1;
            //var mockDb = new Mock<DbSet<CustomerModelPresentation>>();
            var cust = new CustomerModelPresentation
            {
                Custid = 1,
                Companyname = CustomerConsts.Companyname,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Region = CustomerConsts.Region
            };


            mockCustomerPresentation.Setup(x => x.GetById(1)).Returns(ReturnMultiple()[1 - 1]);
            
            //act
            var response = controller.GetById(1);

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as CustomerModelPresentation;

            //assert

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<CustomerModelPresentation>(actualData);
            //Assert.IsType<CustomerModelPresentation>(actualData);
        }

        public List<CustomerModelPresentation> ReturnMultiple()
        {
            return new List<CustomerModelPresentation>()
            {
                new CustomerModelPresentation{
                Custid = 1,
                Companyname = CustomerConsts.Companyname,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Region = CustomerConsts.Region
    },
                new CustomerModelPresentation{
                Custid = 2,
                Companyname = CustomerConsts.Companyname,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Region = CustomerConsts.Region
                },
                new CustomerModelPresentation{
                Custid = 3,
                Companyname = CustomerConsts.Companyname,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Region = CustomerConsts.Region
                }
            };
            /*
             public List<Customer> ReturnMultiple()
        {
            return new List<Customer>()
            {
                new Customer{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Region = CustomerConsts.Region,
                Postalcode = CustomerConsts.Postalcode,
                Fax = CustomerConsts.Fax,
                Contacttitle= CustomerConsts.Contacttitle,
                Contactname = CustomerConsts.Contactname
    },
                new Customer{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Region = CustomerConsts.Region,
                Postalcode = CustomerConsts.Postalcode,
                Fax = CustomerConsts.Fax,
                Contacttitle= CustomerConsts.Contacttitle,
                Contactname = CustomerConsts.Contactname
                },
                new Customer{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Region = CustomerConsts.Region,
                Postalcode = CustomerConsts.Postalcode,
                Fax = CustomerConsts.Fax,
                Contacttitle= CustomerConsts.Contacttitle,
                Contactname = CustomerConsts.Contactname
                }
            };
             */
        }
    }
}
