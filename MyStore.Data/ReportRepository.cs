using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IReportRepository
    {
        List<CustomerContact> GetContacts();
        List<Customer> GetCustomersWithNoOrders();
    }
    public class ReportRepository : IReportRepository
    {
        private readonly StoreContext context;

        public ReportRepository(StoreContext context)
        {
            this.context = context;
        }
        public List<Customer> GetCustomersWithNoOrders()
        {
            var query = context.Customers.FromSqlRaw(@"select c.custid, c.companyname,c.contactname, c.contacttitle,c.address,c.city,
                                                    c.region, c.postalcode, c.country, c.phone, c.fax from Customers as c
                                                    left join Orders on Orders.custid = c.custid
                                                    where Orders.custid is null");
            return query.ToList();
        }

        public List<CustomerContact> GetContacts()
        {
            var query = context.CustomerContact.FromSqlRaw(@"select c.custid, c.address, c.city, c.country from Customers as c
                                                             left join Orders on Orders.custid = c.custid
                                                             where Orders.custid is null");
            var result = query.ToList();
            return result;
        }



    }
}
