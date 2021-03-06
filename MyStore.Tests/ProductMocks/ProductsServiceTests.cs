using Moq;
using MyStore.Domain.Entities;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.ProductMocks
{
    public class ProductsServiceTests
    {
        private readonly Mock<IProductsRepository> repository;
        private readonly ProductService service;
        public ProductsServiceTests()
        {
            repository = new Mock<IProductsRepository>();
            service = new ProductService(repository.Object);
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange
            repository.Setup(x => x.GetAll()).Returns(ReturnMultiple());

            //act
            var actualCategories = service.GetAll();

            //assert
            Assert.Equal(ReturnMultiple().Count, actualCategories.Count());
        }
        [Fact]
        public void ShouldReturn_GetById()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultiple().Where(x => x.Productid == id).AsQueryable();

            //act
            repository.Setup(x => x.GetById(id)).Returns(expectedCategory);
            var actualCategory = service.GetById(id);

            //assert
            Assert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        public void ShouldReturn_OKOnAdd()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultiple()[id];

            //act
            repository.Setup(x => x.Add(It.IsAny<Product>())).Returns(ReturnMultiple()[id]);
            var actualValue = service.Add(ReturnMultiple()[id]);

            //assert
            Assert.Equal(expectedCategory.Productid, actualValue.Productid);
            Assert.IsType<Product>(actualValue);
        }

        [Fact]
        public void ShouldReturn_TrueOnExists()
        {
            //arrange
            repository.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);

            //act
            bool actualValue = service.Exists(1);

            //assert
            Assert.True(actualValue);
        }

        [Fact]
        public void ShouldBeOk_OnUpdate()
        {
            //arrange
            repository.Setup(x => x.Update(It.IsAny<Product>())).Verifiable();

            //act
            service.Update(ReturnMultiple()[0]);

            //assert
            repository.Verify(x => x.Update(It.IsAny<Product>()), Times.Exactly(1));
        }

        [Fact]
        public void ShouldReturn_TrueToDelete()
        {
            //arrange
            repository.Setup(x => x.Delete(It.IsAny<Product>())).Returns(true);

            //act
            bool actualValue = service.Delete(1);

            //assert
            Assert.True(actualValue);
        }
        public List<Product> ReturnMultiple()
        {
            return new List<Product>
            {
                new Product()
                {
                    Productid = 1,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                },
                new Product()
                {
                    Productid = 2,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                },
                new Product()
                {
                    Productid = 3,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                }

            };
        }
    }
}
