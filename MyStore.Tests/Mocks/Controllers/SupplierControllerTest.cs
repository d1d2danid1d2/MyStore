using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Data;
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
    public class SupplierControllerTest
    {
        private Mock<ISupplierService> mockService;

        public SupplierControllerTest()
        {
            mockService = new Mock<ISupplierService>();
        }

        [Fact]
        public void Should_GetOkOnGetAll()
        {

            //arrange
            mockService.Setup(x => x.GetAll()).Returns(ReturnsMultiple);
            var controller = new SupplierController(mockService.Object);

            //act
            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<SupplierModel>;
            //assert


            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<SupplierModel>>(actualData);
        }

        [Fact]
        public void ShouldGetAllSuppliers()
        {
            //arrange
            mockService.Setup(x => x.GetAll()).Returns(ReturnsMultiple);
            var controller = new SupplierController(mockService.Object);

            //act
            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<SupplierModel>;

            //assert
            Assert.Equal(ReturnsMultiple().Count, actualData.Count());
        }
        public List<SupplierModel> ReturnsMultiple()
        {
            return new List<SupplierModel>()
            {
                new SupplierModel
                {
                    Supplierid = SupplierConsts.Supplierid,
                    Companyname = SupplierConsts.Companyname,
                    Contactname = SupplierConsts.Contactname,
                    Contacttitle = SupplierConsts.Contacttitle,
                    Country = SupplierConsts.Country,
                    City = SupplierConsts.City,
                    Address = SupplierConsts.Address,
                    Phone = SupplierConsts.Phone,
                },

                new SupplierModel
                {
                    Supplierid = SupplierConsts.Supplierid,
                    Companyname = SupplierConsts.Companyname,
                    Contactname = SupplierConsts.Contactname,
                    Contacttitle = SupplierConsts.Contacttitle,
                    Country = SupplierConsts.Country,
                    City = SupplierConsts.City,
                    Address = SupplierConsts.Address,
                    Phone = SupplierConsts.Phone,
                }


            };





        }
    }
}
