using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
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
    public class CategoryControllerTests
    {
        private readonly Mock<ICategoryPresentation> presentation;
        private readonly CategoryController controller;
        public CategoryControllerTests()
        {
            presentation = new Mock<ICategoryPresentation>();
            controller = new CategoryController(presentation.Object);
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange

            presentation.Setup(x => x.GetAll()).Returns(ReturnMultipleCategoryModels());


            //act
            var response = controller.Get();
            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<CategoryModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CategoryModel>>(actualData);
        }
        [Fact]
        public void ShouldReturn_GetById()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultipleCategoryProductsModels().Where(x => x.Categoryid == id);

            //act
            presentation.Setup(x => x.GetById(id)).Returns(expectedCategory);
            var response = controller.GetById(id);

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<CategoryProductsModel>;

            //assert
            Assert.Equal(expectedCategory.FirstOrDefault().Categoryid, actualData.FirstOrDefault().Categoryid);
            Assert.IsAssignableFrom<IEnumerable<CategoryProductsModel>>(actualData);
        }

        [Fact]
        public void ShouldReturn_OKOnAdd()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultipleCategoryModels()[id];

            //act
            presentation.Setup(x => x.Add(ReturnMultipleCategoryModels()[id])).Returns(ReturnMultipleCategoryModels()[id]);

            var response = controller.Post(ReturnMultipleCategoryModels()[id]) as JsonResult;
            var actualData = response.Value as IEnumerable<CategoryModel>;

            //assert
            Assert.IsType<CategoryModel>(actualData);
        }

        [Fact]
        public void ShouldBeOk_OnUpdate()
        {
            //arrange
            presentation.Setup(x => x.Update(It.IsAny<CategoryModel>())).Verifiable();

            //act
            controller.Put(1,ReturnMultipleCategoryModels()[0]);

            //assert
            presentation.Verify(x => x.Update(It.IsAny<CategoryModel>()), Times.Exactly(1));
        }

        [Fact]
        public void ShouldReturn_TrueToDelete()
        {
            //arrange
            presentation.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            //act
            var response = controller.Delete(1);
            var data = response as OkObjectResult;
            //assert
            Assert.True((bool)data.Value);
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
