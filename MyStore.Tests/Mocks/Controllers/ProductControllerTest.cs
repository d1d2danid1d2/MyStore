using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests
{
    public class ProductControllerTest
    {
        private Mock<IProductService> mockProductService;
        public ProductControllerTest()
        {
            mockProductService = new Mock<IProductService>();
        }

        [Fact]
        public void Should_Return_OK_On_Get_All()
        {
            //arrange
            mockProductService.Setup(x => x.GetAll()).Returns(MultipleProducts());

            var controller = new ProductsController(mockProductService.Object);
            //act
            
            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;

            //assert

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProductModel>>(actualData);
        }

        [Fact]
        public void Should_Return_All_Products()
        {
            //arrange
            mockProductService.Setup(x => x.GetAll()).Returns(MultipleProducts());
            var controller = new ProductsController(mockProductService.Object);

            //act

            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;

            Assert.Equal(MultipleProducts().Count, actualData.Count());

        }

        private List<ProductModel> MultipleProducts()
        {
            return new List<ProductModel>()
            {
                new ProductModel
                {
                    // Productname = "TestName"; // hardcoded = greu de intretinut 
                    Categoryid =(int)ProductConsts.Category.Condiments,
                    Productid = ProductConsts.TestProduct,
                    Discontinued = false,
                    Supplierid = ProductConsts.TestSupplierId,
                    Productname = ProductConsts.ProductName, // Usor de intretinut 
                    Unitprice = ProductConsts.TestUnitPrice
                },
                 new ProductModel
                {
                   Categoryid =(int)ProductConsts.Category.Condiments,
                    Productid = ProductConsts.TestProduct,
                    Discontinued = false,
                    Supplierid = ProductConsts.TestSupplierId,
                    Productname = ProductConsts.ProductName, 
                    Unitprice = ProductConsts.TestUnitPrice
                },
                  new ProductModel
                {
                    Categoryid =(int)ProductConsts.Category.Condiments,
                    Productid = ProductConsts.TestProduct,
                    Discontinued = false,
                    Supplierid = ProductConsts.TestSupplierId,
                    Productname = ProductConsts.ProductName,
                    Unitprice = ProductConsts.TestUnitPrice
                }
            };
        }



    }
}
