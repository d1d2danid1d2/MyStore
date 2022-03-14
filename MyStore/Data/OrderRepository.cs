﻿using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        IQueryable<Order> GetInfoById(int id);
        Order Add(Order orderToAdd);
        bool Exists(int id);
        void Update(Order updatedOrder);
        bool Delete(Order orderToDelete);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;
        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.ToList();
        }       
        public Order GetById(int id)
        {
            return context.Orders.Find(id);
        }
        public IQueryable<Order> GetInfoById(int id)
        {
            var query = context.Orders.Include(x => x.Emp).Select(x => x);
            if(GetById(id) != null)
            {
                query = query.Where(x => x.Orderid == id);
            }
            return query;
        }
        public Order Add(Order orderToAdd)
        {
            orderToAdd.Orderdate = DateTime.Now;
            orderToAdd.Requireddate = DateTime.Now.AddDays(15);
            var addedOrder = context.Add(orderToAdd);
            context.SaveChanges();
            return addedOrder.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Orders.Count(x => x.Orderid == id);
            return exists == 1;
        }
        public void Update(Order updatedOrder)
        {
            context.Orders.Update(updatedOrder);
            context.SaveChanges();
        }
        public bool Delete(Order orderToDelete)
        {
            var deletedOrder = context.Orders.Remove(orderToDelete);
            context.SaveChanges();
            return deletedOrder != null;
        }
    }
}