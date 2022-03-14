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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderModel>> GetAll()
        {
            var order = orderService.GetAll();
            return Ok(order);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderModel> GetById(int id)
        {
            if (!orderService.Exists(id))
            {
                return NotFound();
            }
            return Ok(orderService.GetById(id));
        }

        [HttpGet("info/{id}")]
        public ActionResult<IEnumerable<Order>> GetAllInfoById(int id)
        {
            if (!orderService.Exists(id))
            {
                return NotFound();
            }
            return Ok(orderService.GetAllInfoById(id));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderModel newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addOrder = orderService.AddOrder(newOrder);
           return CreatedAtAction("GetAll", addOrder, new { id = addOrder.Orderid }); 
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderModel orderToUpdate)
        {
            if (id != orderToUpdate.Orderid)
            {
                return BadRequest();
            }
            if (!orderService.Exists(id))
            {
                return NotFound();
            }
            orderService.Update(orderToUpdate);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!orderService.Exists(id))
            {
                return NotFound();
            }
            orderService.Delete(id);
            return NoContent();
        }
    }
}
