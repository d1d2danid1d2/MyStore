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

namespace MyStore.Tests.CategoryMocks
{
    public class CategoryPresentationTests
    {
        private readonly Mock<ICategoryService> service;
        private readonly CategoryPresentation presentation;
        private readonly Mock<IMapper> mockMapper;
        public CategoryPresentationTests()
        {
            service = new Mock<ICategoryService>();
            mockMapper = new Mock<IMapper>();
            presentation = new CategoryPresentation(service.Object, mockMapper.Object);
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange
            
            mockMapper.Setup(x => x.Map<IEnumerable<CategoryModel>>(service.Object.GetAll())).Returns(ReturnMultipleCategoryModels());


            //act
            var actualValue = presentation.GetAll();

            //assert
            Assert.Equal(ReturnMultipleCategoryModels().Count, actualValue.Count());
            Assert.IsAssignableFrom<IEnumerable<CategoryModel>>(actualValue);
        }
        [Fact]
        public void ShouldReturn_GetById()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultipleCategoryProductsModels().Where(x => x.Categoryid == id);

            //act
            mockMapper.Setup(x => x.Map<IEnumerable<CategoryProductsModel>>(service.Object.GetById(id))).Returns(expectedCategory);
            var actualCategory = presentation.GetById(id);

            //assert
            Assert.Equal(expectedCategory.FirstOrDefault().Categoryid, actualCategory.FirstOrDefault().Categoryid);
            Assert.IsAssignableFrom<IEnumerable<CategoryProductsModel>>(actualCategory);
        }

        [Fact]
        public void ShouldReturn_OKOnAdd()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultiple()[id];

            //act
            mockMapper.Setup(x => x.Map<CategoryModel>(service.Object.Add(It.IsAny<Category>()))).Returns(ReturnMultipleCategoryModels()[id]);

            var actualValue = presentation.Add(ReturnMultipleCategoryModels()[id]);

            //assert
            Assert.Equal(expectedCategory.Categoryid, actualValue.Categoryid);
            Assert.IsType<CategoryModel>(actualValue);
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
            service.Setup(x => x.Update(It.IsAny<Category>())).Verifiable();

            //act
            service.Object.Update(ReturnMultiple()[0]);

            //assert
            service.Verify(x => x.Update(It.IsAny<Category>()), Times.Exactly(1));
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
        public List<Category> ReturnMultiple()
        {
            return new List<Category>
            {
                new Category()
                {
                    Categoryid = 1,
                    Categoryname = "dada",
                    Description = "dwda",
                },
                new Category()
                {
                    Categoryid = 2,
                    Categoryname = "dada",
                    Description = "dwda"
                },
                new Category()
                {
                    Categoryid = 3,
                    Categoryname = "dada",
                    Description = "dwda"
                }

            };
        }
        public List<CategoryModel> ReturnMultipleCategoryModels()
        {
            return new List<CategoryModel>
            {
                new CategoryModel()
                {
                    Categoryid = 1,
                    Categoryname = "dada",
                    Description = "dwda",
                },
                new CategoryModel()
                {
                    Categoryid = 2,
                    Categoryname = "dada",
                    Description = "dwda"
                },
                new CategoryModel()
                {
                    Categoryid = 3,
                    Categoryname = "dada",
                    Description = "dwda"
                }

            };
        }
        public List<CategoryProductsModel> ReturnMultipleCategoryProductsModels()
        {
            return new List<CategoryProductsModel>
            {
                new CategoryProductsModel()
                {
                    Categoryid = 1,
                    Categoryname = "dada",
                    Description = "dwda",
                },
                new CategoryProductsModel()
                {
                    Categoryid = 2,
                    Categoryname = "dada",
                    Description = "dwda"
                },
                new CategoryProductsModel()
                {
                    Categoryid = 3,
                    Categoryname = "dada",
                    Description = "dwda"
                }

            };
        }
    }
}
