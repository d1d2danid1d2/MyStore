using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        IQueryable<Employee> GetInfoById(int id);
        Employee Add(Employee employeeToAdd);
        bool Exists(int id);
        void Update(Employee employeeToUpdate);
        bool Delete(Employee employeeToDelete);
    }
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly StoreContext context;
        public EmployeesRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employees.Find(id);
        }
        public IQueryable<Employee> GetInfoById(int id)
        {
            return context.Employees.Include(x => x.Orders).Select(x => x).Where(x => x.Empid == id);
        }
        public Employee Add(Employee employeeToAdd)
        {
            var addedEmployee = context.Employees.Add(employeeToAdd);
            context.SaveChanges();
            return addedEmployee.Entity;
        }
        public bool Exists(int id)
        {
            var exists = context.Employees.Count(x => x.Empid == id);
            return exists == 1;
        }
        public void Update(Employee employeeToUpdate)
        {
            context.Employees.Update(employeeToUpdate);
            context.SaveChanges();
        }
        public bool Delete(Employee employeeToDelete)
        {
            var deletedEmployee = context.Employees.Remove(employeeToDelete);
            context.SaveChanges();
            return deletedEmployee != null;
        }
    }
}
