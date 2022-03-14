using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IEmploueeService
    {
        IEnumerable<EmployeeModel> GetAll();
        EmployeeModel GetById(int id);
        IEnumerable<EmployeeModel> GetInfoById(int id);
        EmployeeModel Add(EmployeeModel employeeToAdd);
        bool Exists(int id);
        void Update(EmployeeModel employeeToUpdate);
        bool Delete(int id);
    }
    public class EmployeeService : IEmploueeService
    {
        private readonly IEmployeesRepository repository;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            var employee = repository.GetAll().ToList();
            return mapper.Map<IEnumerable<EmployeeModel>>(employee);
        }
        public EmployeeModel GetById(int id)
        {
            var employee = repository.GetById(id);
            return mapper.Map<EmployeeModel>(employee);
        }
        public IEnumerable<EmployeeModel> GetInfoById(int id)
        {
            var employee = repository.GetInfoById(id);
            return mapper.Map<IEnumerable<EmployeeModel>>(employee);
        }
        public EmployeeModel Add(EmployeeModel employeeToAdd)
        {
            Employee newEmployee = mapper.Map<Employee>(employeeToAdd);
            var addedEmployee = repository.Add(newEmployee);
            return mapper.Map<EmployeeModel>(addedEmployee);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(EmployeeModel employeeToUpdate)
        {
            Employee updatedEmployee = mapper.Map<Employee>(employeeToUpdate);
            repository.Update(updatedEmployee);
        }
        public bool Delete(int id)
        {
            var deleteItem = repository.GetById(id);
            repository.Delete(deleteItem);
            return deleteItem != null;
        }
    }
}
