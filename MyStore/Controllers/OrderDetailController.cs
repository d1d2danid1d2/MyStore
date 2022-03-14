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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService service;
        public OrderDetailController(IOrderDetailService service)
        {
            this.service = service;
        }

        // GET: api/<OrderDetailController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetAll ()
        {
            return Ok(service.GetAll());
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetail> GetById(int id)
        {
            if (!service.Exists(id))
            {
                return NotFound();
            }
            return Ok(service.GetById(id));
        }
        [HttpGet("info/{id}/{prodId}")]
        public ActionResult<OrderDetail> GetInfoById(int id, int prodId)
        {
            if (!service.Exists(id))
            {
                return NotFound();
            }
            if(!service.ProdExists(prodId))
            {
                return NotFound();
            }
            return Ok(service.GetInfoById(id, prodId));
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDetail orderToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedOrder = service.Add(orderToAdd);
            return CreatedAtAction("GetAll", addedOrder, new { id = addedOrder.Orderid });
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDetail orderToUpdate)
        {
            if(id != orderToUpdate.Orderid)
            {
                return BadRequest();
            }
            if (!service.Exists(id))
            {
                return NotFound();
            }
            service.Update(orderToUpdate);
            return NoContent();
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.Exists(id))
            {
                return BadRequest();
            }
            service.Delete(id);
            return NoContent();
        }
    }
}
