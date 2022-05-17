using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.OrderMocks
{
    public class OrderRepositoryMocks
    {

        private readonly Mock<IOrderRepository> repository;
        public OrderRepositoryMocks()
        {
            repository = new Mock<IOrderRepository>();
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange
            int? empId = null;
            int? custId = null;
            List<string>? shipCity = null;
            repository.Setup(x => x.GetAll(empId, custId,shipCity)).Returns(ReturnMultiple().AsQueryable());

            //act
            var actualCategories = repository.Object.GetAll(empId, custId, shipCity);

            //assert
            Assert.Equal(ReturnMultiple().Count, actualCategories.Count());
        }
        [Fact]
        public void ShouldReturn_GetById()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultiple().Where(x => x.Orderid == id);

            //act
            repository.Setup(x => x.GetById(id)).Returns(expectedCategory);
            var actualCategory = repository.Object.GetById(id);

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
            repository.Setup(x => x.Add(It.IsAny<Order>())).Returns(ReturnMultiple()[id]);
            var actualValue = repository.Object.Add(ReturnMultiple()[id]);

            //assert
            Assert.Equal(expectedCategory.Orderid, actualValue.Orderid);
            Assert.IsType<Order>(actualValue);
        }

        [Fact]
        public void ShouldReturn_TrueOnExists()
        {
            //arrange
            repository.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);

            //act
            bool actualValue = repository.Object.Exists(1);

            //assert
            Assert.True(actualValue);
        }

        [Fact]
        public void ShouldBeOk_OnUpdate()
        {
            //arrange
            repository.Setup(x => x.Update(It.IsAny<Order>())).Verifiable();

            //act
            repository.Object.Update(ReturnMultiple()[0]);

            //assert
            repository.Verify(x => x.Update(It.IsAny<Order>()), Times.Exactly(1));
        }

        [Fact]
        public void ShouldReturn_TrueToDelete()
        {
            //arrange
            repository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            //act
            bool actualValue = repository.Object.Delete(1);

            //assert
            Assert.True(actualValue);
        }
        public List<Order> ReturnMultiple()
        {
            return new List<Order>
            {
                new Order()
                {                  
                    Orderid = 1,
                    Custid = 1,
                    Empid = 1,
                    Shipperid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Requireddate = new DateTime(2008, 6, 1),
                    Shippeddate = new DateTime(2008, 7, 1),
                    Freight = 12.5M,
                    Shipname = "Test Ship",
                    Shipaddress = "Test Adress",
                    Shipcity = "Test City",
                    Shipregion = "Test Region",
                    Shippostalcode = "Test Postal Code",
                    Shipcountry = "Test Country"
                },
                new Order()
                {
                    Orderid = 2,
                    Custid = 1,
                    Empid = 1,
                    Shipperid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Requireddate = new DateTime(2008, 6, 1),
                    Shippeddate = new DateTime(2008, 7, 1),
                    Freight = 12.5M,
                    Shipname = "Test Ship",
                    Shipaddress = "Test Adress",
                    Shipcity = "Test City",
                    Shipregion = "Test Region",
                    Shippostalcode = "Test Postal Code",
                    Shipcountry = "Test Country"
                },
                new Order()
                {
                    Orderid = 3,
                    Custid = 1,
                    Empid = 1,
                    Shipperid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Requireddate = new DateTime(2008, 6, 1),
                    Shippeddate = new DateTime(2008, 7, 1),
                    Freight = 12.5M,
                    Shipname = "Test Ship",
                    Shipaddress = "Test Adress",
                    Shipcity = "Test City",
                    Shipregion = "Test Region",
                    Shippostalcode = "Test Postal Code",
                    Shipcountry = "Test Country"
                }

            };


        }
    }
}
