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
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<ShipperModel, Shipper>();
            CreateMap<Shipper, ShipperModel>();
        }
    }
}
