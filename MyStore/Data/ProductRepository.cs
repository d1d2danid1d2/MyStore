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
        Product FindProductById(int id);
        Product Add(Product newProduct);
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

        public IEnumerable<Product> FindByCategory(int categoryId)
        {
            return context.Products.Where(x => x.Categoryid == categoryId).ToList();
        }

        public Product FindProductById(int id)
        {
            return context.Products.Find(id);
        }
        public Product Add(Product newProduct)
        {
          var addedProduct = context.Add(newProduct);
            context.SaveChanges();
            return addedProduct.Entity;        
        }

    }
}
