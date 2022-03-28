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
    public interface ISupplierPresentation
    {
        IEnumerable<SupplierModelPresentation> GetAll();
        SupplierModelPresentation GetById(int id);
        SupplierModelAdd Add(SupplierModelAdd addSupplier);
        bool Exists(int id);
        void Update(SupplierModelAdd updateSupplier);
        bool Delete(int id);
    }
    public class SupplierPresentation : ISupplierPresentation
    {
        private readonly ISupplierService service;
        private readonly IMapper mapper;

        public SupplierPresentation(ISupplierService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public IEnumerable<SupplierModelPresentation> GetAll()
        {
            return mapper.Map<IEnumerable<SupplierModelPresentation>>(service.GetAll());
        }
        public SupplierModelPresentation GetById(int id)
        {
            return mapper.Map<SupplierModelPresentation>(service.GetById(id));
        }
        public SupplierModelAdd Add(SupplierModelAdd addSupplier)
        {
            Supplier addedSupplier = mapper.Map<Supplier>(addSupplier);
            return mapper.Map<SupplierModelAdd>(service.Add(addedSupplier));
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public void Update(SupplierModelAdd updateSupplier)
        {
            var addedSupplier = mapper.Map<Supplier>(updateSupplier);
            service.Update(addedSupplier);
        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
