 using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Tests.CategoryMocks
{
    public class CategoryRepositoryTests
    {
        private readonly Mock<ICategoryRepository> repository;
        public CategoryRepositoryTests()
        {
            repository = new Mock<ICategoryRepository>();
        }
        [Fact]
        public void ShouldReturn_OnGetAll()
        {
            //arrange
            repository.Setup(x => x.GetAll()).Returns(ReturnMultiple());

            //act
            var actualCategories = repository.Object.GetAll();

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
            repository.Setup(x => x.GetById(id)).Returns(expectedCategory);
            var actualCategory = repository.Object.GetById(id);

            //assert
            Assert.Equal(expectedCategory, actualCategory);
        }

        [Fact]
        public void ShouldReturn_GetByIdToDelete()
        {
            //arrange
            int id = 2;
            var expectedCategory = ReturnMultiple().Where(x => x.Categoryid == id).FirstOrDefault();

            //act
            repository.Setup(x => x.GetByIdToDelete(id)).Returns(expectedCategory);
            var actualCategory = repository.Object.GetByIdToDelete(id);

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
            repository.Setup(x => x.Add(It.IsAny<Category>())).Returns(ReturnMultiple()[id]);
            var actualValue = repository.Object.Add(ReturnMultiple()[id]);

            //assert
            Assert.Equal(expectedCategory.Categoryid, actualValue.Categoryid);
            Assert.IsType<Category>(actualValue);
        }

        [Fact]
        public void ShouldReturn_TrueOnExists()
        {
            //arrange
            repository.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);

            //act
            bool actualValue = repository.Object.Exists(1);

            //assert
            Assert.True(actualValue);
        }

        [Fact]
        public void ShouldBeOk_OnUpdate()
        {
            //arrange
            repository.Setup(x => x.Update(It.IsAny<Category>())).Verifiable();

            //act
            repository.Object.Update(ReturnMultiple()[0]);

            //assert
            repository.Verify(x => x.Update(It.IsAny<Category>()), Times.Exactly(1));
        }

        [Fact]
        public void ShouldReturn_TrueToDelete()
        {
            //arrange
            repository.Setup(x => x.Delete(It.IsAny<Category>())).Returns(true);

            //act
            bool actualValue = repository.Object.Delete(ReturnMultiple()[0]);

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
