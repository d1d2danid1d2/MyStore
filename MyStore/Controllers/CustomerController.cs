using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Models;
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
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customersService)
        {
            this.customerService = customersService;
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> GetAll()
        {
            var returns = customerService.GetAll();
            return Ok(returns);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerModel> GetById(int id)
        {
            if (!customerService.Exists(id))
            {
                return NotFound();
            }
            return Ok(customerService.GetById(id));
        }

        [HttpGet("info/{id}")]
        public ActionResult<IEnumerable<Customer>> GetInfoById(int id)
        {
            if (!customerService.Exists(id))
            {
                return NotFound();
            }
            return Ok(customerService.GetInfoById(id));
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedCustomer = customerService.AddCustomer(newCustomer);
            return CreatedAtAction("GetAll", addedCustomer, new { id = addedCustomer.Custid });
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerModel customerToUpdate)
        {
            if (id != customerToUpdate.Custid)
            {
                return BadRequest();
            }
            if (!customerService.Exists(id))
            {
                return NotFound();
            }
            customerService.Update(customerToUpdate);
            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!customerService.Exists(id))
            {
                return NotFound();
            }
            customerService.Delete(id);
            return NoContent();
        }
    }
}
