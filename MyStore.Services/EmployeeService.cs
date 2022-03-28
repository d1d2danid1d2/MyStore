using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Add(Employee employeeToAdd);
        bool Exists(int id);
        void Update(Employee employeeToUpdate);
        bool Delete(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository repository;
        public EmployeeService(IEmployeesRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return repository.GetAll();
        }
        public Employee GetById(int id)
        {
            return repository.GetById(id);
        }
        public Employee Add(Employee employeeToAdd)
        {
            return repository.Add(employeeToAdd);
        }
        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        public void Update(Employee employeeToUpdate)
        {
            repository.Update(employeeToUpdate);
        }
        public bool Delete(int id)
        {
            var deleteItem = repository.GetById(id);       
            return repository.Delete(deleteItem);
        }
    }
}
