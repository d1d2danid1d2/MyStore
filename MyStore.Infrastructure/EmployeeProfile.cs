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
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeModel, Employee>();
            CreateMap<Employee, EmployeeModel>();
        }
    }
}
