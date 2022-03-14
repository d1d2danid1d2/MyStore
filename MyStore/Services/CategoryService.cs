using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        IEnumerable<Category> GetInfoById(int id);
        Category Add(Category categoryToAdd);
        bool Exists(int id);
        void Update(Category categoryToUpdate);
        bool Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository repository;
        public CategoryService(ICategoriesRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Category> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public Category GetById(int id)
        {
            return repository.GetById(id);
        }
        public IEnumerable<Category> GetInfoById(int id)
        {
            return repository.GetInfoById(id).ToList();
        }
        public Category Add(Category categoryToAdd)
        {         
            return repository.Add(categoryToAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Category categoryToUpdate)
        {
            repository.Update(categoryToUpdate);
        }
        public bool Delete(int id)
        {
            var deletedItem = repository.GetById(id);
            repository.Delete(deletedItem);
            return deletedItem != null;
        }
    }
}
