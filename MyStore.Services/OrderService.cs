using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll(int? empId, int? custId, List<string>? shipCity);
        IEnumerable<Order> GetById(int id);
        Order Add(Order orderToAdd);
        bool Exists(int id);
        void Update(Order ordetToUpdate);
        bool Delete(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Order> GetAll(int? empId, int? custId, List<string>? shipCity)
        {
            return repository.GetAll(empId, custId, shipCity).ToList();
        }
        public IEnumerable<Order> GetById(int id)
        {
            return repository.GetById(id).ToList();
        }
        public Order Add(Order orderToAdd)
        {
            return repository.Add(orderToAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Order ordetToUpdate)
        {
            repository.Update(ordetToUpdate);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
