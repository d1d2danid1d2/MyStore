using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IReportService
    {
        List<CustomerContact> GetCustomerContact();
        List<Customer> GetCustomersWithNoOrders();
    }
    public class ReportService : IReportService
    {
        private readonly IReportRepository repository;

        public ReportService(IReportRepository repository)
        {
            this.repository = repository;
        }
        public List<Customer> GetCustomersWithNoOrders()
        {
            return repository.GetCustomersWithNoOrders();
        }
        public List<CustomerContact> GetCustomerContact()
        {
            return repository.GetContacts();
        }
    }
}
