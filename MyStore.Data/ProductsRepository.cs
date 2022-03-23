using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
        IQueryable<Product> GetById(int id);
        Product FindById(int id);
        Product Add(Product product);
        bool Exists(int id);
        void Update(Product product);
        bool Delete(Product product);
    }
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreContext context;

        public ProductsRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }
        public IQueryable<Product> GetById(int id)
        {
            return context.Products.Include(x => x.Category).Include(x => x.OrderDetails).Include(x=>x.Supplier).Select(x => x).Where(x => x.Productid == id);
        }
        public Product Add(Product product)
        {
            var newProduct = context.Products.Add(product);
            context.SaveChanges();
            return newProduct.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Products.Count(x => x.Productid == id);
            return exists == 1;
        }
        public void Update(Product product)
        {
            context.Update(product);
            context.SaveChanges();
        }
        public bool Delete(Product product)
        {
            var deletedProduct = context.Products.Remove(product);
            context.SaveChanges();
            return deletedProduct != null;
        }

        public Product FindById(int id)
        {
            return context.Products.Find(id);
        }
    }
}
