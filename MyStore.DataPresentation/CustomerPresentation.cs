using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models.Customer;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.DataPresentation
{
    public interface ICustomerPresentation
    {
        IEnumerable<CustomerModelPresentation> GetAll();
        CustomerModelPresentation GetById(int id);
        CustomerModelAdd Add(CustomerModelAdd toAdd);
        bool Exists(int id);
        void Update(CustomerModelAdd toUpdate);
        bool Delete(int id);
    }
    public class CustomerPresentation : ICustomerPresentation
    {
        private readonly ICustomerService service;
        private readonly IMapper mapper;

        public CustomerPresentation(ICustomerService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public IEnumerable<CustomerModelPresentation> GetAll()
        {
            return mapper.Map<IEnumerable<CustomerModelPresentation>>(service.GetAll());
        }
        public CustomerModelPresentation GetById(int id)
        {
            return mapper.Map<CustomerModelPresentation>(service.GetById(id));
        }
        public CustomerModelAdd Add(CustomerModelAdd toAdd)
        {
            var added = mapper.Map<Customer>(toAdd);
            return mapper.Map<CustomerModelAdd>(service.Add(added));
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public void Update(CustomerModelAdd toUpdate)
        {
            var updated = mapper.Map<Customer>(toUpdate);
            service.Update(updated);
        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
