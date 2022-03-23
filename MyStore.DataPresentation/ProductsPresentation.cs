using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.DataPresentation
{
    public interface IProductPresentation
    {
        IEnumerable<ProductsPresentationModel> GetAll();
        IEnumerable<ProductModel> GetById(int id);
        ProductsPresentationModel Add(ProductsPresentationModel products);
        bool Exists(int id);
        void Update(ProductsPresentationModel products);
        bool Delete(int id);
    }
    public class ProductsPresentation : IProductPresentation
    {
        private readonly IProductService service;
        private readonly IMapper mapper;

        public ProductsPresentation(IProductService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public IEnumerable<ProductsPresentationModel> GetAll()
        {
            var getAll = service.GetAll();
            return mapper.Map<IEnumerable<ProductsPresentationModel>>(getAll);
        }
        public IEnumerable<ProductModel> GetById(int id)
        {
            var getById = service.GetById(id);
            return mapper.Map<IEnumerable<ProductModel>>(getById);
        }
        public ProductsPresentationModel Add(ProductsPresentationModel products)
        {
            Product add = mapper.Map<Product>(products);
            return mapper.Map<ProductsPresentationModel>(service.Add(add));
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public void Update(ProductsPresentationModel products)
        {
            var update = mapper.Map<Product>(products);
            service.Update(update);
        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
