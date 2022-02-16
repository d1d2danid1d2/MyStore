using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    //What it does
    //This is the HTML CRUD (Create, Read, Update, Delete) methods that implements in the webpage
    //This controller takes the "ICustomerService" and stores in the "customerService" field
    //Then we use the methods from the interface

    //Why we do this
    //We do this because of S.O.L.I.D. principles, they states that classes should do one thing only, they need to be encapsulated
    //To be easy changeble, easy mentainable etc, so instead of a big file with all the methods , we split them in separate pieces
    


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustormerService customerService;

        public CustomerController(ICustormerService customersService)
        {
            this.customerService = customersService;
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerService.GetAll();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return customerService.GetById(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
