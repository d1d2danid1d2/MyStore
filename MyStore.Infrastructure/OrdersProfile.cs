
using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;

namespace MyStore.Infrastructure
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderModelAdd>();
            CreateMap<OrderModelAdd, Order>();
            CreateMap<OrderDetailModel, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailModel>();
            CreateMap<OrderModelPresentation, Order>();
            CreateMap<Order, OrderModelPresentation>();
        }       
    }
}
