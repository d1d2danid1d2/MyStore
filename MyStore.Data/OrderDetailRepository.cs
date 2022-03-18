using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        IEnumerable<OrderDetail> GetById(int id);
        OrderDetail Add(OrderDetail orderDetailToAdd);
        bool Exists(int id);
        bool ProductExists(int id, int? prodId);
        void Update(OrderDetail orderDetailToUpdate);
        bool Delete(int id, int? prodId);

    }
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly StoreContext context;

        public OrderDetailRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return context.OrderDetails.ToList();
        }
        public IEnumerable<OrderDetail> GetById(int id)
        {
            return context.OrderDetails.Where(x => x.Orderid == id);
        }
        public OrderDetail Add(OrderDetail orderDetailToAdd)
        {
            var orderAdded = context.OrderDetails.Add(orderDetailToAdd);
            context.SaveChanges();
            return orderAdded.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.OrderDetails.Count(x => x.Orderid == id);
            return exists >= 1;
        }
        public bool ProductExists(int id, int? prodId)
        {
            var order = GetById(id);
            if (prodId == null)
            {
                order.FirstOrDefault();
                return true;
            }
             
            var exists = order.Count(x => x.Productid == prodId);    
            return exists == 1;
        }
        public void Update(OrderDetail orderDetailToUpdate)
        {
            //var updatedOrder = context.OrderDetails.First(x => x.Productid == orderDetailToUpdate.Productid);
            //updatedOrder = orderDetailToUpdate;
            context.OrderDetails.Update(orderDetailToUpdate);
            context.SaveChanges();
        }
        public bool Delete(int id, int? productId)
        {
            var deleteOrders = new OrderDetail();
            if (productId != null)
            {
                deleteOrders = GetById(id).First(x => x.Productid == productId);
                context.OrderDetails.Remove(deleteOrders);
            }
            else
            {
                deleteOrders = GetById(id).FirstOrDefault();
                context.OrderDetails.Remove(deleteOrders);
            }

            context.SaveChanges();
            return deleteOrders != null;
        }
    }
}
