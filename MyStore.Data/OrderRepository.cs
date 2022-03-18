using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Data
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll(int? empId, int? custId, List<string>? shipCity);
        IEnumerable<Order> GetById(int id);
        Order Add(Order orderToAdd);
        bool Exists(int id);
        void Update(Order orderToUpdate);
        bool Delete(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> GetAll(int? empId, int? custId, List<string>? shipCity)
        {
            var query = this.context.Orders.Include(x => x.OrderDetails).Select(x => x);
            if (empId != null)
            {
                query = query.Where(x => x.Empid == empId);
            }
            if (custId != null)
            {
                query = query.Where(x => x.Custid == custId);
            }
            if(shipCity.Any())
            {
                query = query.Where(x => shipCity.Contains(x.Shipcountry));
            }
            return query;
        }
        public IEnumerable<Order> GetById(int id)
        {
            return context.Orders.Include(x => x.OrderDetails).Where(x => x.Orderid == id);
        }
        public Order Add(Order orderToAdd)
        {
            var addedOrder = context.Orders.Add(orderToAdd);
            context.SaveChanges();
            return addedOrder.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Orders.Count(x => x.Orderid == id);
            return exists == 1;
        }
        public void Update(Order orderToUpdate)
        {
            context.Orders.Update(orderToUpdate);
            context.SaveChanges();
        }
        public bool Delete(int id )
        {
            var deletedOrderDetail = FindOrderById(id);
            foreach (var item in deletedOrderDetail)
            {
                context.Remove(item);
            }
            var deleteOrder = FindById(id);
            context.Remove(deleteOrder);
            context.SaveChanges();
            return deleteOrder != null;
        }

        // for delete
        // 
        public Order FindById(int id)
        {
            return context.Orders.Find(id);
        }
        public IEnumerable<OrderDetail> FindOrderById(int id)
        {
            return context.OrderDetails.Where(x => x.Orderid == id);
        }
    }
}
