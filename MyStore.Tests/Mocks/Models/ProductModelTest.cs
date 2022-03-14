using MyStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests
{
    public class ProductModelTest
    {
        private const string Expected = "The Productname field is required.";
        private const int CategoryId = 2;

        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.Equal(2, 2);
        //}

        [Fact]
        public void ShouldPass()
        {
            //arrange
            var sut = new ProductModel()
            {
                Categoryid = CategoryId,
                Productid = ProductConsts.TestProduct,
                Supplierid = ProductConsts.TestSupplierId,
                Unitprice = ProductConsts.TestUnitPrice,
                Discontinued = true,
                Productname = ProductConsts.ProductName
            };

            //act
            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResult, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]
        public void Should_Fail_When_ProductName_isEmpty()
        {
            //arrange
            var sut = new ProductModel()
            {
                Categoryid = CategoryId,
                Productid = ProductConsts.TestProduct,
                Supplierid = ProductConsts.TestSupplierId,
                Unitprice = ProductConsts.TestUnitPrice,
                Discontinued = true,
                Productname = ""
            };

            //act
            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResult, true);

            var message = validationResult[0];

            //assert
            Assert.Equal(Expected, message.ErrorMessage);

        }

    }
}
