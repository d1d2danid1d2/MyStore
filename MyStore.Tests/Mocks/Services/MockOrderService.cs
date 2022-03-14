using Moq;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Mocks.Services
{
    class MockOrderService : Mock<IOrderService>
    {
        public MockOrderService MockAllOrders(List<OrderModel> result)
        {
            Setup(x => x.GetAll()).Returns(result);
            return this;
        }

        public MockOrderService MockGetById(OrderModel result)
        {
            Setup(x => x.GetById(It.IsAny<int>())).Returns(result);
            return this;
        }

    }
}
