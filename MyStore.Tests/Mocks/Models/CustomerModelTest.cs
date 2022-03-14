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
    public class CustomerModelTest
    {
        private const string Expected = "The Contactname field is required.";
        [Fact]
        public void ShouldPass()
        {
            //arrange
            var cust = new CustomerModel()
            {
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = CustomerConsts.Contactname,
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone
            };

            //act

            var validationResult = new List<ValidationResult>();
            var result = Validator.TryValidateObject(cust, new ValidationContext(cust), validationResult, true);

            //assert
            Assert.True(result, "Expected to succeed");
        }

        [Fact]
        public void Should_FailWhen_ContactNameIsEmpty()
        {
            var cust = new CustomerModel()
            {
                Custid = CustomerConsts.Custid,
                Companyname = CustomerConsts.Companyname,
                Contactname = "",
                Contacttitle = CustomerConsts.Contacttitle,
                Country = CustomerConsts.Country,
                Address = CustomerConsts.Address,
                City = CustomerConsts.City,
                Phone = CustomerConsts.Phone
            };

            //act

            var validationResult = new List<ValidationResult>();
            var result = Validator.TryValidateObject(cust, new ValidationContext(cust), validationResult, true);

            var message = validationResult[0];

            //assert
            Assert.Equal(Expected, message.ErrorMessage);
        }



    }
}
