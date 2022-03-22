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
    public interface ICategoryPresentation
    {
        IEnumerable<CategoryModel> GetAll();
        IEnumerable<CategoryProductsModel> GetById(int id);
        CategoryModel Add(CategoryModel model);
        bool Exists(int id);
        void Update(CategoryModel model);
        bool Delete(int id);
    }
    public class CategoryPresentation : ICategoryPresentation
    {
        private readonly ICategoryService service;
        private readonly IMapper mapper;

        public CategoryPresentation(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public IEnumerable<CategoryModel> GetAll()
        {
            return mapper.Map<IEnumerable<CategoryModel>>(service.GetAll());
        }
        public IEnumerable<CategoryProductsModel> GetById(int id)
        {
            return mapper.Map<IEnumerable<CategoryProductsModel>>(service.GetById(id));
        }
        public CategoryModel Add(CategoryModel model)
        {
            var category = mapper.Map<Category>(model);
            var addedCategory = service.Add(category);
            return mapper.Map<CategoryModel>(addedCategory);          
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public void Update(CategoryModel model)
        {
            var updateCategory = mapper.Map<Category>(model);
            service.Update(updateCategory);
        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
