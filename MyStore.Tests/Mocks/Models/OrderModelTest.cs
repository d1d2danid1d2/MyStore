using MyStore.Models;
using MyStore.Tests.Mocks.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.Mocks.Models
{
    public class OrderModelTest
    {
        public string Expected = "The Shipaddress field is required.";
        [Fact]
        public void ShouldPass()
        {
            //arrange
            var order = new OrderModel()
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
            };

            //act
            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(order, new ValidationContext(order), validationResult, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]
        public void Should_FailWhen_ShippAdress_IsNull()
        {
            //arrange
            var order = new OrderModel()
            {
                Custid = OrderConsts.CustId,
                Empid = OrderConsts.EmpId,
                Orderdate = OrderConsts.Orderdate,
                Freight = OrderConsts.Freight,
                Orderid = OrderConsts.OrderId,
                Requireddate = OrderConsts.Requireddate,
                Shipaddress ="",
                Shipcity = OrderConsts.Shipcity,
                Shipcountry = OrderConsts.Shipcountry,
                Shipname = OrderConsts.Shipname,
                Shipperid = OrderConsts.ShipperId
            };

            //act
            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(order, new ValidationContext(order), validationResult, true);
            var message = validationResult[0];

            //assert
            Assert.Equal(Expected, message.ErrorMessage);
        }
    }
}
