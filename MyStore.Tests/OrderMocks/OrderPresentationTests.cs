using AutoMapper;
using Moq;
using MyStore.DataPresentation;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.OrderMocks
{
    public class OrderPresentationTests
    {
        private readonly Mock<IOrderService> service;
        private readonly Mock<IMapper> mapper;
        private readonly OrdersPresentation presentation;
        public OrderPresentationTests()
        {
            service = new Mock<IOrderService>();
            mapper = new Mock<IMapper>();
            presentation = new OrdersPresentation(service.Object, mapper.Object);
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange
            int? empId = null;
            int? custId = null;
            List<string>? shipCity = null;
            mapper.Setup(x => x.Map<IEnumerable<OrderModelPresentation>>(service.Object.GetAll(empId, custId, shipCity))).Returns(ReturnMultipleOrdersPresentationModels());

            //act
            var actualCategories = presentation.GetAll(empId, custId, shipCity);

            //assert
            Assert.Equal(ReturnMultipleOrdersPresentationModels().Count, actualCategories.Count());
        }
        [Fact]
        public void ShouldReturn_GetById()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultipleOrdersPresentationModels().Where(x => x.Orderid == id);

            //act
            mapper.Setup(x => x.Map<IEnumerable<OrderModelPresentation>>(service.Object.GetById(id))).Returns(expectedCategory);
            var actualCategory = presentation.GetById(id);

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
            mapper.Setup(x => x.Map<OrderModelAdd>(service.Object.Add(It.IsAny<Order>()))).Returns(ReturnMultiple()[id]);
            var actualValue = presentation.Add(ReturnMultiple()[id]);

            //assert
            Assert.Equal(expectedCategory.Orderid, actualValue.Orderid);
            Assert.IsType<OrderModelAdd>(actualValue);
        }

        [Fact]
        public void ShouldReturn_TrueOnExists()
        {
            //arrange
            service.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);

            //act
            bool actualValue = presentation.Exists(1);

            //assert
            Assert.True(actualValue);
        }

        [Fact]
        public void ShouldBeOk_OnUpdate()
        {
            //arrange
            service.Setup(x => x.Update(It.IsAny<Order>())).Verifiable();

            //act
            presentation.Update(ReturnMultiple()[0]);

            //assert
            service.Verify(x => x.Update(It.IsAny<Order>()), Times.Exactly(1));
        }

        [Fact]
        public void ShouldReturn_TrueToDelete()
        {
            //arrange
            service.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            //act
            bool actualValue = presentation.Delete(1);

            //assert
            Assert.True(actualValue);
        }
        public List<OrderModelAdd> ReturnMultiple()
        {
            return new List<OrderModelAdd>
            {
                new OrderModelAdd()
                {
                    Orderid = 1,
                    Custid = 1,
                    Empid = 1,
                    Shipperid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Requireddate = new DateTime(2008, 6, 1),
                    Freight = 12.5M,
                    Shipname = "Test Ship",
                    Shipaddress = "Test Adress",
                    Shipcity = "Test City",
                    Shipcountry = "Test Country"
                },
                new OrderModelAdd()
                {
                    Orderid = 2,
                    Custid = 1,
                    Empid = 1,
                    Shipperid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Requireddate = new DateTime(2008, 6, 1),
                    Freight = 12.5M,
                    Shipname = "Test Ship",
                    Shipaddress = "Test Adress",
                    Shipcity = "Test City",
                    Shipcountry = "Test Country"
                },
                new OrderModelAdd()
                {
                    Orderid = 3,
                    Custid = 1,
                    Empid = 1,
                    Shipperid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Requireddate = new DateTime(2008, 6, 1),
                    Freight = 12.5M,
                    Shipname = "Test Ship",
                    Shipaddress = "Test Adress",
                    Shipcity = "Test City",
                    Shipcountry = "Test Country"
                }
            };
        }
        public List<OrderModelPresentation> ReturnMultipleOrdersPresentationModels()
        {
            return new List<OrderModelPresentation>
            {
                new OrderModelPresentation()
                {
                    Orderid = 1,
                    Custid = 1,
                    Empid = 1,                   
                    Orderdate = new DateTime(2008, 5, 1),
                    Shipcountry = "Test Country"
                },
                new OrderModelPresentation()
                {
                    Orderid = 2,
                    Custid = 1,
                    Empid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Shipcountry = "Test Country"
                },
                new OrderModelPresentation()
                {
                    Orderid = 3,
                    Custid = 1,
                    Empid = 1,
                    Orderdate = new DateTime(2008, 5, 1),
                    Shipcountry = "Test Country"
                }
            };
        }
    }
}
