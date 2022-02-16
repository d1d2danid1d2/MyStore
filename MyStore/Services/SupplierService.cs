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
    public interface ISupplierService
    {
        SupplierModel AddSupplier(SupplierModel newSupplier);
        IEnumerable<SupplierModel> GetAllSuppliers();
        SupplierModel GetById(int id);
    }


    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            var getAllSuppliers = supplierRepository.GetAll().ToList();
            return mapper.Map<IEnumerable<SupplierModel>>(getAllSuppliers);

        }

        public SupplierModel GetById(int id)
        {
            var getById = supplierRepository.GetById(id);
            return mapper.Map<SupplierModel>(getById);
        }

        public SupplierModel AddSupplier(SupplierModel newSupplier)
        {
            Supplier addSupplier = mapper.Map<Supplier>(newSupplier);
            var addedSupplier = supplierRepository.Add(addSupplier);
            return mapper.Map<SupplierModel>(addedSupplier);
        }
    }
}
