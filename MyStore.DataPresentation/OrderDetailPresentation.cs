using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.DataPresentation
{
    public interface IOrderDetailPresentation
    {
        IEnumerable<OrderDetailModel> GetAll();
        IEnumerable<OrderDetailModel> GetById(int id);
        OrderDetailModel Add(OrderDetailModel orderDetailToAdd);
        bool Exists(int id);
        bool ProductExists(int id, int? prodId);
        void Update(OrderDetailModel orderDetailToUpdate, int? productId);
        bool Delete(int id, int? productId);
    }
    public class OrderDetailPresentation : IOrderDetailPresentation
    {
        private readonly IOrderDetailService service;
        private readonly IMapper mapper;

        public OrderDetailPresentation(IOrderDetailService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public IEnumerable<OrderDetailModel> GetAll()
        {
            return mapper.Map<IEnumerable<OrderDetailModel>>(service.GetAll());
        }
        public IEnumerable<OrderDetailModel> GetById(int id)
        {
            return mapper.Map<IEnumerable<OrderDetailModel>>(service.GetById(id));
        }
        public OrderDetailModel Add(OrderDetailModel orderDetailToAdd)
        {
            OrderDetail addOrder = mapper.Map<OrderDetail>(orderDetailToAdd);
            return mapper.Map<OrderDetailModel>(service.Add(addOrder));
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public bool ProductExists(int id, int? prodId)
        {
            return service.ProductExists(id, prodId);
        }
        public void Update(OrderDetailModel orderDetailToUpdate, int? productId)
        {
            OrderDetail addedOrder = mapper.Map<OrderDetail>(orderDetailToUpdate);
            service.Update(addedOrder, productId);
        }
        public bool Delete(int id, int? productId)
        {
            return service.Delete(id, productId);
        }   
    }
}
