using Moq;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public class MockProductService : Mock<IProductService>
    {
      public MockProductService MockGetAllProducts(List<ProductModel> result)
        {
            Setup(x => x.GetAll()).Returns(result);
            return this;
        }

        public MockProductService MockById(ProductModel product)
        {
            Setup(x => x.GetById(It.IsAny<int>())).Returns(product);
                //.Throws(new Exception("Product with id not found"));
            return this;
        }
    }   
}
