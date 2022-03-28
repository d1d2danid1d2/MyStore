using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infrastructure
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierModelPresentation, Supplier>();
            CreateMap<Supplier, SupplierModelPresentation>();
            CreateMap<Supplier, SupplierModelAdd>();
            CreateMap<SupplierModelAdd, Supplier>();
        }
    }
}
