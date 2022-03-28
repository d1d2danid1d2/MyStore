using Microsoft.AspNetCore.Mvc;
using MyStore.DataPresentation;
using MyStore.Models;
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
        private readonly ISupplierPresentation presentation;

        public SupplierController(ISupplierPresentation presentation) 
        {
            this.presentation = presentation;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public ActionResult<IEnumerable<SupplierModelPresentation>> Get()
        {
            return Ok(presentation.GetAll());
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public ActionResult<SupplierModelPresentation> GetById(int id)
        {
            if(!presentation.Exists(id))
            {
                return NotFound();
            }
            return Ok(presentation.GetById(id));
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierModelAdd supplierToAdd)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var created = presentation.Add(supplierToAdd);
            return CreatedAtAction("Get", created, new { id = created.Supplierid });
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierModelAdd supplierToUpdate)
        {
            if(!presentation.Exists(id))
            {
                return NotFound();
            }
            if(id != supplierToUpdate.Supplierid)
            {
                return BadRequest();
            }
            presentation.Update(supplierToUpdate);
            return NoContent();
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!presentation.Exists(id))
            {
                return NotFound();
            }
            presentation.Delete(id);
            return NoContent();
        }
    }
}
