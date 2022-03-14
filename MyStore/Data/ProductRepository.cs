using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IProductRepository
    {
        //Data access code
        //CRUD
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        IQueryable<Product> GetInfoById(int id);     
        Product Add(Product productToAdd);
        bool Exists(int id);
        void Update(Product productToUpdate);       
        bool Delete(Product productToDelete);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;
        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }
        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }
        public IQueryable<Product> GetInfoById(int id)
        {
            var query = context.Products.Include(x => x.Supplier).Include(x => x.Category).Select(x => x);
            query = query.Where(x => x.Productid == id);
            return query;
        }
        public Product Add(Product productToAdd)
        {
            var addedProduct = context.Add(productToAdd);
            context.SaveChanges();
            return addedProduct.Entity;        
        }
        public bool Exists(int id)
        {
            var exist = context.Products.Count(x => x.Productid == id);
            return exist == 1;
        }
        public void Update(Product productToUpdate)
        {
            context.Products.Update(productToUpdate);
            context.SaveChanges();
        }
        public bool Delete(Product productToDelete)
        {
            var deletedItem = context.Products.Remove(productToDelete);
            context.SaveChanges();
            return deletedItem != null;
        }
    }
}
