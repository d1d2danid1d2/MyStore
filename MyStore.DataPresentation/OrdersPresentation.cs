using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;

namespace MyStore.DataPresentation
{
    public interface IOrdersPresentation
    {
        IEnumerable<OrderModelPresentation> GetAll(int? empId, int? custId, List<string>? shipCity);
        IEnumerable<OrderModelPresentation> GetById(int id);
        OrderModelAdd Add(OrderModelAdd orderToAdd);
        bool Exists(int id);
        void Update(OrderModelAdd orderToUpdate);
        bool Delete(int id);
    }
    public class OrdersPresentation : IOrdersPresentation
    {
        private readonly IOrderService service;
        private readonly IMapper mapper;

        public OrdersPresentation(IOrderService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public IEnumerable<OrderModelPresentation>GetAll(int? empId, int? custId, List<string>? shipCity)
        {
            return mapper.Map<IEnumerable<OrderModelPresentation>>(service.GetAll(empId, custId, shipCity));
        }
        public IEnumerable<OrderModelPresentation> GetById(int id)
        {
            var order = service.GetById(id);
            return mapper.Map<IEnumerable<OrderModelPresentation>>(order);
        }
        public OrderModelAdd Add(OrderModelAdd orderToAdd)
        {
            Order newOrder = mapper.Map<Order>(orderToAdd);
            return mapper.Map<OrderModelAdd>(service.Add(newOrder));
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public void Update(OrderModelAdd orderToUpdate)
        {
            Order updatedOrder = mapper.Map<Order>(orderToUpdate);
            service.Update(updatedOrder);
        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
