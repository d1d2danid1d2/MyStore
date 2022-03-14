using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests
{
    public class ProductRepositoryTest
    {
        private Mock<IProductRepository> mockRepo;
        public ProductRepositoryTest()
        {
            mockRepo = new Mock<IProductRepository>();
        }

        [Fact]
        public void Should_GetAllProducts()
        {
            //arrange 

            mockRepo.Setup(repo => repo.GetAll()).Returns(ReturnMultiple);

            //act

            var result = mockRepo.Object.GetAll();

            //assert 
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Product>>(result);
        }

        //[Fact]
        //public void Should_GetByID()
        //{
        //    //arrange
        //    var productList = ReturnMultiple();
        //    mockRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(ReturnMultiple()[It.IsAny<int>()]);

        //    //act 
        //    int id = 1;
        //    var result = mockRepo.Object.GetById(id);
        //    var expected = ReturnMultiple().Find(x => x.Productid == id);
        //    //assert
        //    Assert.Equal(expected, result);
        //    Assert.Equal(expected.Productid,result.Productid);
        //}
            

        public List<Product> ReturnMultiple()
        {
            return new List<Product>()
            {
                new Product{
                Categoryid = ProductConsts.CategoryId,
                Productid = 1,
                Supplierid = ProductConsts.TestSupplierId,
                Unitprice = ProductConsts.TestUnitPrice,
                Discontinued = true,
                Productname = ProductConsts.ProductName
            },
                new Product{
                Categoryid = ProductConsts.CategoryId,
                Productid = 2,
                Supplierid = ProductConsts.TestSupplierId,
                Unitprice = ProductConsts.TestUnitPrice,
                Discontinued = true,
                Productname = ProductConsts.ProductName
            }

            };
        }


    }
}
