using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetById(int id);
        Category Add(Category category);
        bool Exists(int id);
        void Update(Category category);
        bool Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Category> GetAll()
        {
            return repository.GetAll();
        }
        public IEnumerable<Category> GetById(int id)
        {
            return repository.GetById(id);
        }
        public Category Add(Category category)
        {
            return repository.Add(category);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Category category)
        {
            repository.Update(category);
        }
        public bool Delete(int id)
        {
            var itemToDelete = repository.GetByIdToDelete(id);
            return repository.Delete(itemToDelete);
        }

    }
}
