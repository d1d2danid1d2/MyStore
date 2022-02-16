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
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplier;

        public SupplierController(ISupplierService supplier)
        {
            this.supplier = supplier;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<SupplierModel> Get()
        {
            return supplier.GetAllSuppliers();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public SupplierModel Get(int id)
        {
            return supplier.GetById(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierModel newSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedSupplier = supplier.AddSupplier(newSupplier);

            return CreatedAtAction("Get", addedSupplier, new { id = addedSupplier.Supplierid });
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
