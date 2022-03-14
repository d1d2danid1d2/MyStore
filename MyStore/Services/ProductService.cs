using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel GetById(int id);
        IEnumerable<Product> GetInfoById(int id);
        ProductModel Add(ProductModel productToAdd);
        bool Exists(int id);
        void Update(ProductModel productToUpdate);
        bool Delete(int id);    
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            //take domain object
            var allProduct = productRepository.GetAll().ToList();

            //transform domain objects from List<Product> -> List<ProductModel>
            return mapper.Map<IEnumerable<ProductModel>>(allProduct);
        }
        public ProductModel GetById(int id)
        {
            var findObject = productRepository.GetById(id);
            return mapper.Map<ProductModel>(findObject);
        }
        public IEnumerable<Product> GetInfoById(int id)
        {
            return productRepository.GetInfoById(id).ToList();
        }
        public ProductModel Add(ProductModel productToAdd)
        {
            // ProductModel -> Product
            // Assuming is valid  -> we transform it in Product(Domain object)
            Product newProduct = mapper.Map<Product>(productToAdd);
            var addedProduct = productRepository.Add(newProduct);
            return mapper.Map<ProductModel>(addedProduct);
        }
        public bool Exists(int id)
        {
            return productRepository.Exists(id);
        }
        public void Update(ProductModel productToUpdate)
        {
            Product updatedProduct = mapper.Map<Product>(productToUpdate);
            productRepository.Update(updatedProduct);
        }
        public bool Delete(int id)
        {
            var itemToDelete = productRepository.GetById(id);
            productRepository.Delete(itemToDelete);
            return productRepository != null;
        }
    }
}
