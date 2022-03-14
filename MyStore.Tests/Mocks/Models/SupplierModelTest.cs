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
    public class SupplierModelTest
    {
        private const string Expected = "The Contactname field is required.";
        [Fact]
        public void ShouldPass()
        {
            //arrange
            var rep = new SupplierModel()
            {
                Supplierid = SupplierConsts.Supplierid,
                Contactname = SupplierConsts.Contactname,
                Companyname = SupplierConsts.Companyname,
                Contacttitle = SupplierConsts.Contacttitle,
                Address = SupplierConsts.Address,
                Country = SupplierConsts.Country,
                City = SupplierConsts.City,
                Phone = SupplierConsts.Phone
            };

            //act
            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(rep, new ValidationContext(rep), validationResult, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]
        public void Should_FailWhen_ContactName_IsEmpty()
        {
            //arrange
            var rep = new SupplierModel()
            {
                Supplierid = SupplierConsts.Supplierid,
                Contactname ="",
                Companyname = SupplierConsts.Companyname,
                Contacttitle = SupplierConsts.Contacttitle,
                Address = SupplierConsts.Address,
                Country = SupplierConsts.Country,
                City = SupplierConsts.City,
                Phone = SupplierConsts.Phone
            };

            //act
            var validationResult = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(rep, new ValidationContext(rep), validationResult, true);

            var message = validationResult[0];

            Assert.Equal(Expected, message.ErrorMessage);
        }


    }
}
