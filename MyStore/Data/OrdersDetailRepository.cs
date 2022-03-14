using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IOrdersDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail GetById(int id);
        IQueryable<OrderDetail> GetInfoById(int id);
        OrderDetail Add(OrderDetail orderDetailToAdd);
        bool Exists(int id);
        void Update(OrderDetail orderDetailToUpdate);
        bool Delete(OrderDetail orderDetailToDelete);
    }
    public class OrdersDetailRepository :IOrdersDetailRepository
    {
        private readonly StoreContext context;
        public OrdersDetailRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return context.OrderDetails.ToList();
        }
        public OrderDetail GetById(int id)
        {
            return context.OrderDetails.Find(id);
        }
        public IQueryable<OrderDetail> GetInfoById(int id)
        {
            return context.OrderDetails.Include(x => x.Productid).Select(x => x).Where(x => x.Productid == id);
        }
        public OrderDetail Add(OrderDetail orderDetailToAdd)
        {
            var addedOrderDetail = context.OrderDetails.Add(orderDetailToAdd);
            context.SaveChanges();
            return addedOrderDetail.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.OrderDetails.Count(x => x.Orderid == id);
            return exists == 1;
        }
        public void Update(OrderDetail orderDetailToUpdate)
        {
            context.OrderDetails.Update(orderDetailToUpdate);
            context.SaveChanges();
        }
        public bool Delete(OrderDetail orderDetailToDelete)
        {
            var deletedOrder = context.OrderDetails.Remove(orderDetailToDelete);
            context.SaveChanges();
            return deletedOrder != null;
        }




    }
}
