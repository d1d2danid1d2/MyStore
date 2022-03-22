using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        IQueryable<Category> GetById(int id);
        Category GetByIdToDelete(int id);
        Category Add(Category categoryToAdd);
        bool Exists(int id);
        void Update(Category category);
        bool Delete(Category category);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext context;

        public CategoryRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public IQueryable<Category> GetById(int id)
        {
            return context.Categories.Include(x => x.Products).Select(x => x).Where(x => x.Categoryid == id);
        }
        public Category GetByIdToDelete(int id)
        {
            return context.Categories.Find(id);
        }
        public Category Add(Category categoryToAdd)
        {
            var addedCategory = context.Categories.Add(categoryToAdd);
            context.SaveChanges();
            return addedCategory.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Categories.Count(x => x.Categoryid == id);
            return exists == 1;
        }

        public void Update(Category category)
        {
            var categoryToUpdate = context.Categories.Update(category);
            context.SaveChanges();
        }
        public bool Delete(Category category) 
        {
            var deleted = context.Categories.Remove(category);
            context.SaveChanges();
            return deleted != null;
        }
    }
}
