using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Models.Customer;
using MyStore.Services;
using MyStore.Tests.Mocks.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.Mocks.Controllers
{
    public class CustomerControllerTest
    {
        private Mock<ICustomerService> mockCustomerService;

        public CustomerControllerTest()
        {
            mockCustomerService = new Mock<ICustomerService>();
        }

        [Fact]
        public void Should_ReturnOkOn_GetAll()
        {
            //arrange
            mockCustomerService.Setup(x => x.GetAll()).Returns(ReturnMultiple);
            var controller = new CustomerController(mockCustomerService.Object);

            //act
            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<CustomerModelPresentation>;

            //assert

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CustomerModel>>(actualData);
        }

        [Fact]
        public void Should_ReturnAll_Customers()
        {
            //arrange
            mockCustomerService.Setup(x => x.GetAll()).Returns(ReturnMultiple);
            var controller = new CustomerController(mockCustomerService.Object);

            //act
            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<CustomerModelPresentation>;

            //assert
            Assert.Equal(ReturnMultiple().Count, actualData.Count());
        }


        public List<Customer> ReturnMultiple()
        {
            return new List<Customer>()
            {
                new Customer{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = CustomerConsts.Contactname,
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone, 
                Fax = CustomerConsts.Fax,
                Postalcode = CustomerConsts.Postalcode,
                Region = CustomerConsts.Region
    },
                new Customer{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = CustomerConsts.Contactname,
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Fax = CustomerConsts.Fax,
                Postalcode = CustomerConsts.Postalcode,
                Region = CustomerConsts.Region
                },
                new Customer{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = CustomerConsts.Contactname,
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone,
                Fax = CustomerConsts.Fax,
                Postalcode = CustomerConsts.Postalcode,
                Region = CustomerConsts.Region
                }
            };
        }
    }
}
