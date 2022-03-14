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
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplier)
        {
            this.supplierService = supplier;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public ActionResult<IEnumerable<SupplierModel>> GetAll()
        {
            var result = supplierService.GetAll();
            return Ok(result);
        }
        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public ActionResult<SupplierModel> GetById(int id)
        {
            if (!supplierService.Exists(id))
            {
                return NotFound();
            }
            return Ok(supplierService.GetById(id));
        }

        [HttpGet("info/{id}")]
        public ActionResult<IEnumerable<Supplier>> GetInfoById(int id)
        {
            if (!supplierService.Exists(id))
            {
                return NotFound();
            }
            return Ok(supplierService.GetInfoById(id));
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierModel newSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedSupplier = supplierService.Add(newSupplier);

            return CreatedAtAction("GetAll", addedSupplier, new { id = addedSupplier.Supplierid });
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierModel supplierToUpdate)
        {
            if (id != supplierToUpdate.Supplierid)
            {
                return BadRequest();
            }
            if (!supplierService.Exists(id))
            {
                return NotFound();
            }
            supplierService.Update(supplierToUpdate);
            return NoContent();
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!supplierService.Exists(id))
            {
                return NotFound();
            }
            supplierService.Delete(id);
            return NoContent();

        }
    }
}
