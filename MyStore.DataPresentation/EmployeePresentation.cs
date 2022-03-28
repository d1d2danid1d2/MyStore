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
    public interface IEmployeePresentation
    {
        IEnumerable<EmployeeModel> GetAll();
        EmployeeModel GetById(int id);
        EmployeeModel Add(EmployeeModel employeeToAdd);
        bool Exists(int id);
        void Update(EmployeeModel employeeToUpdate);
        bool Delete(int id);
    }
    public class EmployeePresentation : IEmployeePresentation
    {
        private readonly IEmployeeService service;
        private readonly IMapper mapper;

        public EmployeePresentation(IEmployeeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public IEnumerable<EmployeeModel> GetAll()
        {
            var employee = service.GetAll().ToList();
            return mapper.Map<IEnumerable<EmployeeModel>>(employee);
        }
        public EmployeeModel GetById(int id)
        {
            var employee = service.GetById(id);
            return mapper.Map<EmployeeModel>(employee);
        }
        public EmployeeModel Add(EmployeeModel employeeToAdd)
        {
            Employee newEmployee = mapper.Map<Employee>(employeeToAdd);
            var addedEmployee = service.Add(newEmployee);
            return mapper.Map<EmployeeModel>(addedEmployee);
        }
        public bool Exists(int id)
        {
            return service.Exists(id);
        }
        public void Update(EmployeeModel employeeToUpdate)
        {
            Employee updatedEmployee = mapper.Map<Employee>(employeeToUpdate);
            service.Update(updatedEmployee);
        }
        public bool Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
