using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail GetById(int id);
        IEnumerable<OrderDetail> GetInfoById(int id);
        OrderDetail Add(OrderDetail orderDetailToAdd);
        bool Exists(int id);
        void Update(OrderDetail orderDetailToUpdate);
        bool Delete(int id);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrdersDetailRepository repository;
        public OrderDetailService(IOrdersDetailRepository repository)
        {
            this.repository = repository;
        }
        
        public IEnumerable<OrderDetail> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public OrderDetail GetById(int id)
        {
            return repository.GetById(id);
        }
        public IEnumerable<OrderDetail> GetInfoById(int id)
        {
            return repository.GetInfoById(id).ToList();
        }
        public OrderDetail Add(OrderDetail orderDetailToAdd)
        {
            return repository.Add(orderDetailToAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(OrderDetail orderDetailToUpdate)
        {
            repository.Update(orderDetailToUpdate);
        }
        public bool Delete(int id)
        {
            var deletedItem = repository.GetById(id);
            repository.Delete(deletedItem);
            return deletedItem != null;
        }
    }
}
