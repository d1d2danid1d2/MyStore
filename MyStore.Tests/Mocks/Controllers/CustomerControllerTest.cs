using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Models;
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
            var actualData = result.Value as IEnumerable<CustomerModel>;

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
            var actualData = result.Value as IEnumerable<CustomerModel>;

            //assert
            Assert.Equal(ReturnMultiple().Count, actualData.Count());
        }


        public List<CustomerModel> ReturnMultiple()
        {
            return new List<CustomerModel>()
            {
                new CustomerModel{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = CustomerConsts.Contactname,
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone
                },
                new CustomerModel{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = CustomerConsts.Contactname,
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone
                },
                new CustomerModel{
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = CustomerConsts.Contactname,
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone
                }
            };
        }
    }
}
