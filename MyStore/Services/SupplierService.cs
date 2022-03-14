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
        IEnumerable<SupplierModel> GetAll();
        SupplierModel GetById(int id);
        IEnumerable<Supplier> GetInfoById(int id);
        SupplierModel Add(SupplierModel supplierToAdd);
        bool Exists(int id);
        void Update(SupplierModel updateModel);
        bool Delete(int id);
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

        public IEnumerable<SupplierModel> GetAll()
        {
            var getAllSuppliers = supplierRepository.GetAll().ToList();
            return mapper.Map<IEnumerable<SupplierModel>>(getAllSuppliers);

        }
        public SupplierModel GetById(int id)
        {
            var getById = supplierRepository.GetById(id);
            return mapper.Map<SupplierModel>(getById);
        }
        public IEnumerable<Supplier> GetInfoById(int id)
        {
            return supplierRepository.GetInfoById(id).ToList();
        }
        public SupplierModel Add(SupplierModel supplierToAdd)
        {
            Supplier addSupplier = mapper.Map<Supplier>(supplierToAdd);
            var addedSupplier = supplierRepository.Add(addSupplier);
            return mapper.Map<SupplierModel>(addedSupplier);
        }
        public bool Exists(int id)
        {
            return supplierRepository.Exists(id);
        }
        public void Update(SupplierModel modelToUpdate)
        {
            Supplier supplierToUpdate = mapper.Map<Supplier>(modelToUpdate);
            supplierRepository.Update(supplierToUpdate);
        }
        public bool Delete(int id)
        {
            var supplierToDelete = supplierRepository.GetById(id);
            supplierRepository.Delete(supplierToDelete);
            return supplierToDelete != null;
        }
    }
}
