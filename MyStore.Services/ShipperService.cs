using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetAll();
        Shipper GetById(int id);
        Shipper Add(Shipper toAdd);
        bool Exists(int id);
        void Update(Shipper toUpdate);
        bool Delete(int id);
    }
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository repository;

        public ShipperService(IShipperRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Shipper> GetAll()
        {
            return repository.GetAll();
        }
        public Shipper GetById(int id)
        {
            return repository.GetById(id);
        }
        public Shipper Add(Shipper toAdd)
        {
            return repository.Add(toAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Shipper toUpdate)
        {
            repository.Update(toUpdate);
        }
        public bool Delete(int id)
        {
            var deleteShipper = repository.GetById(id);
            return repository.Delete(deleteShipper);
        }
    }
}
