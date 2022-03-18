using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAll();
        IEnumerable<OrderDetail> GetById(int id);
        OrderDetail Add(OrderDetail orderDetailToAdd);
        bool Exists(int id);
        bool ProductExists(int id, int? prodId);
        void Update(OrderDetail orderDetailToUpdate, int? productId);
        bool Delete(int id, int? productId);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository repository;

        public OrderDetailService(IOrderDetailRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            {
                return repository.GetAll();
            }
        }
        public IEnumerable<OrderDetail> GetById(int id)
        {
            return repository.GetById(id);
        }
        public OrderDetail Add(OrderDetail orderDetailToAdd)
        {
            return repository.Add(orderDetailToAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public bool ProductExists(int id, int? prodId)
        {
            return repository.ProductExists(id, prodId);
        }
        public void Update(OrderDetail orderDetailToUpdate, int? productId)
        {
            if (productId == null || productId == orderDetailToUpdate.Productid)
            {
                repository.Update(orderDetailToUpdate); 
            }
            else if (repository.ProductExists(orderDetailToUpdate.Orderid, (int)productId))
            {
                repository.Delete(orderDetailToUpdate.Orderid, productId);
                Add(orderDetailToUpdate);
            }
            else if(!repository.ProductExists(orderDetailToUpdate.Orderid,(int)productId))
            {
                repository.Delete(orderDetailToUpdate.Orderid, productId);
                repository.Add(orderDetailToUpdate);
            }           
        }
        public bool Delete(int id, int? productId)
        {
            return repository.Delete(id, productId);
        }

    }
}
