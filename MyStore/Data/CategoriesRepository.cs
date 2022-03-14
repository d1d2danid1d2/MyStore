using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        IQueryable<Category> GetInfoById(int id);
        Category Add(Category categoryToAdd);
        bool Exists(int id);
        void Update(Category categoryToUpdate);
        bool Delete(Category categoryToDelete);
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly StoreContext context;
        public CategoriesRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }
        public IQueryable<Category> GetInfoById(int id)
        {
            return context.Categories.Include(x => x.Products).Select(x => x).Where(x => x.Categoryid == id);
        }
        public Category Add(Category categoryToAdd)
        {
            var addedCategory = context.Add(categoryToAdd);
            context.SaveChanges();
            return addedCategory.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Categories.Count(x=>x.Categoryid == id);
            return exists == 1;
        }
        public void Update(Category categoryToUpdate)
        {
            context.Categories.Update(categoryToUpdate);
            context.SaveChanges();
        }
        public bool Delete(Category categoryToDelete)
        {
            var deletedCategory = context.Categories.Remove(categoryToDelete);
            context.SaveChanges();
            return deletedCategory != null;
        }
    }
}
