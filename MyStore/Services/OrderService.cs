﻿using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderModel> GetAll();
        public OrderModel GetById(int id);
        public IEnumerable<Order> GetAllInfoById(int id);
        public OrderModel AddOrder(OrderModel addOrder);
        public bool Exists(int id);
        public void Update(OrderModel updateOrder);
        public bool Delete(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<OrderModel> GetAll()
        {
            var allProducts = repository.GetAll().ToList();
            return mapper.Map<IEnumerable<OrderModel>>(allProducts);
        }

        public OrderModel GetById(int id)
        {
            var findOrder = repository.GetById(id);
            return mapper.Map<OrderModel>(findOrder);
        }

        public IEnumerable<Order> GetAllInfoById(int id)
        {
            return repository.GetInfoById(id);
        }

        public OrderModel AddOrder(OrderModel addOrder)
        {
            Order newOrder = mapper.Map<Order>(addOrder);
            var added = repository.Add(newOrder);
            return mapper.Map<OrderModel>(added);
        }

        public bool Exists(int id)
        {
            return repository.Exists(id);
        }

        public void Update(OrderModel updateOrder)
        {
            Order orderUpdate = mapper.Map<Order>(updateOrder);
            repository.Update(orderUpdate);
        }

        public bool Delete(int id)
        {
            var orderId = repository.GetById(id);
            repository.Delete(orderId);
            return repository != null;
        }
    }
}