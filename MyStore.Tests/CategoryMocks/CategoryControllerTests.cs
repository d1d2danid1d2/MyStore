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

namespace MyStore.Tests
{
    public class CategoryControllerTests
    {
        private readonly Mock<ICategoryPresentation> mockPresentation = new Mock<ICategoryPresentation>();
        private readonly Mock<ICategoryService> mockService = new Mock<ICategoryService>();
        private readonly CategoryController controller;

        public CategoryControllerTests()
        {
            controller = new CategoryController(mockPresentation.Object);
        }

        [Fact]
        public void ShouldSomething()
        {
            int cat = 1;
            var category = new List<CategoryProductsModel>() {
            new CategoryProductsModel()
            {
                Categoryid = cat,
                Categoryname = "dada",
                Description = "dwda"

            }}.AsEnumerable();

            mockPresentation.Setup(x => x.GetById(cat)).Returns(RetunMultiple());

            var response = controller.GetById(cat);
            var result = response.Result as OkObjectResult;
            var actualData = result.Value as CategoryProductsModel;

            Assert.Equal(1, actualData.Categoryid);
        }
        public List<CategoryProductsModel> RetunMultiple()
        {
            return new List<CategoryProductsModel>
            {
                new CategoryProductsModel()
                {
                    Categoryid = 1,
                    Categoryname = "dada",
                    Description = "dwda"
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
