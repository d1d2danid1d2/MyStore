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
        ProductModel AddProduct(ProductModel newProduct);
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetById(int id);
    }
    public class ProductService :IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            //take domain object
            var allProduct = productRepository.GetAll().ToList();

            //transform domain objects from List<Product> -> List<ProductModel>
            var productModels = mapper.Map<IEnumerable<ProductModel>>(allProduct);


            return productModels;
        }

        public ProductModel GetById(int id)
        {
            var findObject = productRepository.FindProductById(id);

            return mapper.Map<ProductModel>(findObject);
        }

        public ProductModel AddProduct(ProductModel newProduct)
        {

            // ProductModel -> Product
            // Assuming is valid  -> we transform it in Product(Domain object)
            Product productToAdd = mapper.Map<Product>(newProduct);
            var addedProduct = productRepository.Add(productToAdd);
            newProduct = mapper.Map<ProductModel>(addedProduct);
            return newProduct;
        }

    }
}




/*          o metoda de a face trecerea (munca de chinez batran :)) )
            for (int i = 0; i < allProduct.Count(); i++)
            {
                
                var productModel = new ProductModel();
                productModel.Categoryid = allProduct[i].Categoryid;
                productModel.Productid = allProduct[i].Productid;
                productModel.Productname = allProduct[i].Productname;
                productModel.Unitprice = allProduct[i].Unitprice;
                productModel.Discontinued = allProduct[i].Discontinued;
                productModel.Supplierid = allProduct[i].Supplierid;
            }
*/