using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class OrderDetailService
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




    }
}
