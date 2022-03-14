using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Tests.Mocks.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.Mocks.Repository
{
    public class OrderRepositoryTest
    {
        private Mock<IOrderRepository> mockRepo;

        public OrderRepositoryTest()
        {
            mockRepo = new Mock<IOrderRepository>();
        }

        [Fact]
        public void Should_ReturnGetAll()
        {
            //assert
            mockRepo.Setup(x => x.GetAll()).Returns(ReturnsMultiple);

            //act
            var result = mockRepo.Object.GetAll();

            //assert
            Assert.Equal(2, ReturnsMultiple().Count);
            Assert.IsType<List<Order>>(result);

        }
        public List<Order> ReturnsMultiple()
        {
            return new List<Order>
            {
                new Order
                {
                    Custid = OrderConsts.CustId,
                    Empid = OrderConsts.EmpId,
                    Freight = OrderConsts.Freight,
                    Orderdate = OrderConsts.Orderdate,
                    Orderid = OrderConsts.OrderId,
                    Requireddate = OrderConsts.Requireddate,
                    Shipaddress = OrderConsts.Shipaddress,
                    Shipcity = OrderConsts.Shipcity,
                    Shipcountry = OrderConsts.Shipcountry,
                    Shipname = OrderConsts.Shipname,
                    Shippeddate = OrderConsts.Shippeddate,
                    Shipperid = OrderConsts.ShipperId,
                    Shippostalcode = OrderConsts.Shippostalcode,
                    Shipregion = OrderConsts.Shipregion                   
                },
                new Order
                {
                    Custid = OrderConsts.CustId,
                    Empid = OrderConsts.EmpId,
                    Freight = OrderConsts.Freight,
                    Orderdate = OrderConsts.Orderdate,
                    Orderid = OrderConsts.OrderId,
                    Requireddate = OrderConsts.Requireddate,
                    Shipaddress = OrderConsts.Shipaddress,
                    Shipcity = OrderConsts.Shipcity,
                    Shipcountry = OrderConsts.Shipcountry,
                    Shipname = OrderConsts.Shipname,
                    Shippeddate = OrderConsts.Shippeddate,
                    Shipperid = OrderConsts.ShipperId,
                    Shippostalcode = OrderConsts.Shippostalcode,
                    Shipregion = OrderConsts.Shipregion
                }

            };
        }






    }
}
