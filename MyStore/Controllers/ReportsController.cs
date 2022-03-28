using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Domain.Extensions;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService service;

        public ReportsController(IReportService service)
        {
            this.service = service;
        }
        // GET: api/<ReportsController>
        [HttpGet]
        public ActionResult<List<Customer>> CustomersWithNoOrders()
        {
            return service.GetCustomersWithNoOrders();
        }
        [HttpGet("/contacts")]
        public ActionResult<List<CustomerContact>> CustomerContacts()
        {
            var contacts = service.GetCustomerContact();
            return contacts;
        }

        // GET api/<ReportsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReportsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReportsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
