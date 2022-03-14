using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetAll();
        Shipper GetById(int id);
        IEnumerable<Shipper> GetInfoById(int id);
        Shipper Add(Shipper shipperToAdd);
        bool Exists(int id);
        void Update(Shipper shipperToUpdate);
        bool Delete(int id);
    }
    public class ShipperService : IShipperService
    {
        private readonly IShippersRepository repository;
        public ShipperService(IShippersRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Shipper> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public Shipper GetById(int id)
        {
            return repository.GetById(id);
        }
        public IEnumerable<Shipper> GetInfoById(int id)
        {
            return repository.GetInfoById(id).ToList();
        }
        public Shipper Add(Shipper shipperToAdd)
        {
            return repository.Add(shipperToAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Shipper shipperToUpdate)
        {
            repository.Update(shipperToUpdate);
        }
        public bool Delete(int id)
        {
            var deleteItem = repository.GetById(id);
            repository.Delete(deleteItem);
            return deleteItem != null;
        }
    }
}
