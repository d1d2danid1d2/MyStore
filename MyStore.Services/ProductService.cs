using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetById(int id);
        Product Add(Product product);
        bool Exists(int id);
        void Update(Product product);
        bool Delete(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductsRepository repository;

        public ProductService(IProductsRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Product> GetAll()
        {
            return repository.GetAll();
        }
        public IEnumerable<Product> GetById(int id)
        {
            return repository.GetById(id);
        }
        public Product Add(Product product)
        {
            return repository.Add(product);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Product product)
        {
            repository.Update(product);
        }
        public bool Delete(int id)
        {
            var product = repository.FindById(id);
            return repository.Delete(product);
        }
    }
}
