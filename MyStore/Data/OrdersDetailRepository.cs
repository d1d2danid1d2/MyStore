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
        IEnumerable<OrderDetail> GetById(int id);
        OrderDetail OrderDelete(int id);
        IQueryable<OrderDetail> GetInfoById(int id, int prodId);
        OrderDetail Add(OrderDetail orderDetailToAdd);
        bool Exists(int id);
        bool ProdExists(int prodId);
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
        public IEnumerable<OrderDetail> GetById(int id)
        {
            return context.OrderDetails.Where(x => x.Orderid == id).ToList();
        }
        public OrderDetail OrderDelete(int id)
        {
            return context.OrderDetails.FirstOrDefault(x=>x.Orderid == id);
        }
        public IQueryable<OrderDetail> GetInfoById(int id, int prodId)
        {
            return context.OrderDetails.Include(x => x.Product).Select(x => x).Where(x => x.Productid == prodId);
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
            
            return exists >= 1;
        }
        public bool ProdExists(int prodId)
        {
            var exists = context.OrderDetails.Count(x => x.Productid == prodId);

            return exists >= 1;
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
