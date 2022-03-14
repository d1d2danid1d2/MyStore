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
    public class SupplierRepositoryTest
    {
        private Mock<ISupplierRepository> mockrepo;

        public SupplierRepositoryTest()
        {
            mockrepo = new Mock<ISupplierRepository>();
        }

        [Fact]
        public void Should_GetAllSuppliers()
        {
            //arrange
            mockrepo.Setup(x => x.GetAll()).Returns(ReturnsMultiple);

            //act
            var result = mockrepo.Object.GetAll();

            //assert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Supplier>>(result);
        }

        public List<Supplier> ReturnsMultiple()
        {
            return new List<Supplier>()
            {
                new Supplier
                {
                    Supplierid = SupplierConsts.Supplierid,
                    Companyname = SupplierConsts.Companyname,
                    Contactname = SupplierConsts.Contactname,
                    Contacttitle = SupplierConsts.Contacttitle,
                    Country = SupplierConsts.Country,
                    City = SupplierConsts.City,
                    Region = SupplierConsts.Region,
                    Postalcode = SupplierConsts.Postalcode,
                    Address = SupplierConsts.Address,
                    Phone = SupplierConsts.Phone,
                    Fax = SupplierConsts.Fax
                },
            
                new Supplier
                {
                    Supplierid = SupplierConsts.Supplierid,
                    Companyname = SupplierConsts.Companyname,
                    Contactname = SupplierConsts.Contactname,
                    Contacttitle = SupplierConsts.Contacttitle,
                    Country = SupplierConsts.Country,
                    City = SupplierConsts.City,
                    Region = SupplierConsts.Region,
                    Postalcode = SupplierConsts.Postalcode,
                    Address = SupplierConsts.Address,
                    Phone = SupplierConsts.Phone,
                    Fax = SupplierConsts.Fax
                }


            };

        }



    }
}
