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

namespace MyStore.Tests.ProductMocks
{
    public class ProductsPresentationTests
    {
        private readonly Mock<IProductService> service;
        private readonly Mock<IMapper> mapper;
        private readonly ProductsPresentation presentation;
        public ProductsPresentationTests()
        {
            service = new Mock<IProductService>();
            mapper = new Mock<IMapper>();
            presentation = new ProductsPresentation(service.Object, mapper.Object);
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange
            mapper.Setup(x => x.Map<IEnumerable<ProductsPresentationModel>>(service.Object.GetAll())).Returns(ReturnMultipleProductsPresentationModels());

            //act
            var actualCategories = presentation.GetAll();

            //assert
            Assert.Equal(ReturnMultipleProductsPresentationModels().Count, actualCategories.Count());
        }
        [Fact]
        public void ShouldReturn_GetById()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultipleProductsModels().Where(x => x.Productid == id).ToList();

            //act
            mapper.Setup(x => x.Map<IEnumerable<ProductModel>>(service.Object.GetById(id))).Returns(expectedCategory);
            var actualCategory = presentation.GetById(id);

            //assert
            Assert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        public void ShouldReturn_OKOnAdd()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultipleProductsPresentationModels()[id];

            //act
            mapper.Setup(x => x.Map<ProductsPresentationModel>(service.Object.Add(It.IsAny<Product>()))).Returns(ReturnMultipleProductsPresentationModels()[id]);
            var actualValue = presentation.Add(ReturnMultipleProductsPresentationModels()[id]);

            //assert
            Assert.Equal(expectedCategory.Productid, actualValue.Productid);
            Assert.IsType<ProductsPresentationModel>(actualValue);
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
            service.Setup(x => x.Update(It.IsAny<Product>())).Verifiable();

            //act
            presentation.Update(ReturnMultipleProductsPresentationModels()[0]);

            //assert
            service.Verify(x => x.Update(It.IsAny<Product>()), Times.Exactly(1));
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
  
        public List<ProductModel> ReturnMultipleProductsModels()
        {
            return new List<ProductModel>
            {
                new ProductModel()
                {
                    Productid = 1,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                },
                new ProductModel()
                {
                    Productid = 2,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                },
                new ProductModel()
                {
                    Productid = 3,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                }

            };
        }
        public List<ProductsPresentationModel> ReturnMultipleProductsPresentationModels()
        {
            return new List<ProductsPresentationModel>
            {
                new ProductsPresentationModel()
                {
                    Productid = 1,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                },
                new ProductsPresentationModel()
                {
                    Productid = 2,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                },
                new ProductsPresentationModel()
                {
                    Productid = 3,
                    Productname = "TestName",
                    Supplierid = 2,
                    Categoryid = 1,
                    Unitprice = 100,
                    Discontinued = false
                }

            };
        }
    }
}
