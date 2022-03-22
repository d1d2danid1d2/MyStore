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
            var newOrderId = orderDetailToUpdate.Orderid;
            var newProductId = orderDetailToUpdate.Productid;
            if (repository.ProductExists(newOrderId, newProductId) && productId != newProductId && productId != null)
            {
                var firstOldOrder = repository.GetById(newOrderId).First(x => x.Productid == newProductId);
                var oldOrder = repository.GetById(newOrderId).First(x => x.Productid == productId);
                repository.Delete(oldOrder);
                repository.Update(firstOldOrder, orderDetailToUpdate);
            }
            else if (productId == null || newProductId == productId)
            {
                if(productId == null)
                {
                    var oldOrder = repository.GetById(newOrderId).FirstOrDefault();
                    repository.Update(oldOrder, orderDetailToUpdate);
                }
                else
                {
                    var oldOrder = repository.GetById(newOrderId).First(x => x.Productid == newProductId);
                    repository.Update(oldOrder, orderDetailToUpdate);
                }
                
            }
            else if(repository.ProductExists(newOrderId, (int)productId))
            {
                var oldOrder = repository.GetById(newOrderId).First(x => x.Productid == productId);
                repository.Update(oldOrder, orderDetailToUpdate);            
            }          
        }
        public bool Delete(int id, int? productId)
        {
            var orderToDelete = repository.GetById(id);
            if (productId == null)
            {
                var deleteOrder = orderToDelete.FirstOrDefault();
                return repository.Delete(deleteOrder);
            }
            else
            {
                var deleteOrder = orderToDelete.First(x => x.Productid == productId);
                return repository.Delete(deleteOrder);
            }
            
        }

    }
}
