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
    public class OrderControllerTest
    {
        private Mock<IOrderService> mockOrderRepo;

        public OrderControllerTest()
        {
            mockOrderRepo = new Mock<IOrderService>();
        }

        [Fact]
        public void Should_Return_OkOn_GetAll()
        {
            //arrange
            mockOrderRepo.Setup(x => x.GetAll()).Returns(ReturnMultiple);
            var controller = new OrdersController(mockOrderRepo.Object);

            //act
            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<OrderModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<OrderModel>>(actual);       
        }
        [Fact]
        public void Should_Return_AllOrders_Count()
        {
            //arrange
            mockOrderRepo.Setup(x => x.GetAll()).Returns(ReturnMultiple);
            var controller = new OrdersController(mockOrderRepo.Object);

            //act
            var response = controller.GetAll();

            var result = response.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<OrderModel>;

            //assert
            Assert.Equal(ReturnMultiple().Count, actual.Count());
        }

        public List<OrderModel> ReturnMultiple()
        {
            return new List<OrderModel>()
            {
                new OrderModel
                {
                    Custid = OrderConsts.CustId,
                    Empid = OrderConsts.EmpId,
                    Orderdate = OrderConsts.Orderdate,
                    Freight = OrderConsts.Freight,
                    Orderid = OrderConsts.OrderId,
                    Requireddate = OrderConsts.Requireddate,
                    Shipaddress = OrderConsts.Shipaddress,
                    Shipcity = OrderConsts.Shipcity,
                    Shipcountry = OrderConsts.Shipcountry,
                    Shipname = OrderConsts.Shipname,
                    Shipperid = OrderConsts.ShipperId

                },
                new OrderModel
                {
                    Custid = OrderConsts.CustId,
                    Empid = OrderConsts.EmpId,
                    Orderdate = OrderConsts.Orderdate,
                    Freight = OrderConsts.Freight,
                    Orderid = OrderConsts.OrderId,
                    Requireddate = OrderConsts.Requireddate,
                    Shipaddress = OrderConsts.Shipaddress,
                    Shipcity = OrderConsts.Shipcity,
                    Shipcountry = OrderConsts.Shipcountry,
                    Shipname = OrderConsts.Shipname,
                    Shipperid = OrderConsts.ShipperId

                }
            };
        }
    }
}
