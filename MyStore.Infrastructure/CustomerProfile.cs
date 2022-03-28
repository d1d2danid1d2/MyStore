using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrastructure
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModelPresentation>();
            CreateMap<CustomerModelPresentation, Customer>();
            CreateMap<Customer, CustomerModelAdd>();
            CreateMap<CustomerModelAdd, Customer > ();
        }
    }
}
