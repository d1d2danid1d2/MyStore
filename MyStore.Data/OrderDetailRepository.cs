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
        void Update(OrderDetail orderDetailToUpdate);
        bool Delete(int id);
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
            return orderAdded.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.OrderDetails.Count(x => x.Orderid == id);
            return exists >= 1;         
        }
        public void Update(OrderDetail orderDetailToUpdate)
        {
            var updatedOrder = context.OrderDetails.Update(orderDetailToUpdate);
            context.SaveChanges();
        }
        public bool Delete(int id)
        {
            var deleteOrders = GetById(id);
            foreach (var item in deleteOrders)
            {
                context.Remove(item);
            }
            context.SaveChanges();
            return deleteOrders != null;
        }
    }
}
