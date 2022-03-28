using Microsoft.AspNetCore.Mvc;
using MyStore.DataPresentation;
using MyStore.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerPresentation presentation;

        public CustomerController(ICustomerPresentation presentation)
        {
            this.presentation = presentation;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModelPresentation>> Get()
        {
            return Ok(presentation.GetAll());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerModelPresentation> GetById(int id)
        {
            if (!presentation.Exists(id))
            {
                return NotFound();
            }
            return Ok(presentation.GetById(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModelAdd toAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var added = presentation.Add(toAdd);
            return CreatedAtAction("Get", added, new { id = added.Custid });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerModelAdd toUpdate)
        {
            if (!presentation.Exists(id))
            {
                return NotFound();
            }
            if (id != toUpdate.Custid)
            {
                return BadRequest();
            }
            presentation.Update(toUpdate);
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
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
