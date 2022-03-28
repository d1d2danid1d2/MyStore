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
    public interface IShipperPresentation
    {
        IEnumerable<ShipperModel> GetAll();
        ShipperModel GetById(int id);
        ShipperModel Add(ShipperModel toAdd);
        bool Exists(int id);
        void Update(ShipperModel toUpdate);
        bool Delete(int id);
    }
    public class ShipperPresentation : IShipperPresentation
    {
        private readonly IShipperService service;
        private readonly IMapper mapper;

        public ShipperPresentation(IShipperService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public IEnumerable<ShipperModel> GetAll()
        {
            var getAll = mapper.Map<IEnumerable<ShipperModel>>(service.GetAll());
            return getAll;
        }
        public ShipperModel GetById(int id)
        {
            var getById = mapper.Map<ShipperModel>(service.GetById(id));
            return getById;
        }
        public ShipperModel Add(ShipperModel toAdd)
        {
            var shipperToAdd = mapper.Map<Shipper>(toAdd);
            var addedShipper = service.Add(shipperToAdd);
            return mapper.Map<ShipperModel>(addedShipper);
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public void Update(ShipperModel toUpdate)
        {
            var shipperToUpdate = mapper.Map<Shipper>(toUpdate);
            service.Update(shipperToUpdate);
        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
