using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests.CategoryMocks
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> mockRepo;
        private readonly CategoryService service;
        public CategoryServiceTests()
        {
            mockRepo = new Mock<ICategoryRepository>();
            service = new CategoryService(mockRepo.Object);
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange
            mockRepo.Setup(x => x.GetAll()).Returns(ReturnMultiple());

            //act
            var actualCategories = service.GetAll();

            //assert
            Assert.Equal(ReturnMultiple().Count, actualCategories.Count());
        }
        [Fact]
        public void ShouldReturn_GetById()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultiple().Where(x => x.Categoryid == id).AsQueryable();           

            //act
            mockRepo.Setup(x => x.GetById(id)).Returns(expectedCategory);
            var actualCategory = service.GetById(id);
            
            //assert
            Assert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        public void ShouldReturn_OKOnAdd()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultiple()[id];

            //act
            mockRepo.Setup(x => x.Add(It.IsAny<Category>())).Returns(ReturnMultiple()[id]);
            var actualValue = service.Add(ReturnMultiple()[id]);
            
            //assert
            Assert.Equal(expectedCategory.Categoryid, actualValue.Categoryid);
            Assert.IsType<Category>(actualValue);
        }

        [Fact]
        public void ShouldReturn_TrueOnExists()
        {
            //arrange
            mockRepo.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);

            //act
            bool actualValue = service.Exists(1);

            //assert
            Assert.True(actualValue);
        }

        [Fact]
        public void ShouldBeOk_OnUpdate()
        {
            //arrange
            mockRepo.Setup(x => x.Update(It.IsAny<Category>())).Verifiable();

            //act
            service.Update(ReturnMultiple()[0]);

            //assert
            mockRepo.Verify(x=>x.Update(It.IsAny<Category>()),Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldReturn_TrueToDelete()
        {
            //arrange
            mockRepo.Setup(x => x.Delete(It.IsAny<Category>())).Returns(true);

            //act
            bool actualValue = service.Delete(1);

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
                    Description = "dwda"
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

    }
}
