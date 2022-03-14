using Microsoft.EntityFrameworkCore;
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

        //[Fact]

        //public void Should_GetById()
        //{
        //    //arrange
        //    mockrepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(ReturnsMultiple()[It.IsAny<int>()]);

        //    //act
        //    int id = ReturnsMultiple().FindIndex(x => x.Supplierid == 1);
        //    var result = mockrepo.Object.GetById(id);
        //    var expected = ReturnsMultiple().Find(x => x.Supplierid == 2);

        //    //assert
        //    Assert.Equal(expected.Phone, result.Phone);
        //}


        public List<Supplier> ReturnsMultiple()
        {
            return new List<Supplier>()
            {
                new Supplier
                {                    
                    Supplierid = 1,
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
                    Supplierid = 2,
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
