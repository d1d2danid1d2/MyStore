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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersPresentation orders;

        public OrdersController(IOrdersPresentation orders)
        {
            this.orders = orders;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderModelPresentation>> Get(int? empId, int? custId, [FromQuery]List<string>? shipCity)
        {
            return Ok(orders.GetAll(empId,custId,shipCity));
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<OrderModelPresentation>> GetById(int id)
        {
            if (!orders.Exists(id))
            {
                return NotFound();
            }
            return Ok(orders.GetById(id));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<OrderModelAdd> Post([FromBody] OrderModelAdd orderToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var orderAdded = orders.Add(orderToAdd);
            return CreatedAtAction("Get", orderAdded, new { id = orderAdded.Orderid });
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderModelAdd orderToUpdate)
        {
            if(!orders.Exists(id))
            {
                return NotFound();
            }
            if(id != orderToUpdate.Orderid)
            {
                return BadRequest();
            }
            orders.Update(orderToUpdate);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!orders.Exists(id))
            {
                return NotFound();
            }
            orders.Delete(id);
            return NoContent();
        }
    }
}
