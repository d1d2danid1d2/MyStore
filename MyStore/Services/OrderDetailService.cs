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
        IEnumerable<OrderDetail> GetById(int id);
        IEnumerable<OrderDetail> GetInfoById(int id, int prodId);
        OrderDetail Add(OrderDetail orderDetailToAdd);
        bool Exists(int id);
        bool ProdExists(int prodId);
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
        public IEnumerable<OrderDetail> GetById(int id)
        {
            return repository.GetById(id);
        }
        public IEnumerable<OrderDetail> GetInfoById(int id, int prodId)
        {
            return repository.GetInfoById(id, prodId).ToList();
        }
        public OrderDetail Add(OrderDetail orderDetailToAdd)
        {
            return repository.Add(orderDetailToAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public bool ProdExists(int prodId)
        {
            return repository.ProdExists(prodId);
        }
        public void Update(OrderDetail orderDetailToUpdate)
        {
            repository.Update(orderDetailToUpdate);
        }
        public bool Delete(int id)
        {
            var deletedItem = repository.OrderDelete(id);
            repository.Delete(deletedItem);
            return deletedItem != null;
        }
    }
}
