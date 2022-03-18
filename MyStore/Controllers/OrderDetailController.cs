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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailPresentation orderDetail;

        public OrderDetailController(IOrderDetailPresentation orderDetail)
        {
            this.orderDetail = orderDetail;
        }

        // GET: api/<OrderDetailController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetailModel>> Get()
        {
            return Ok(orderDetail.GetAll());
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<OrderDetailModel>> GetById(int id)
        {
            if (!orderDetail.Exists(id))
            {
                return NotFound();
            }
            return Ok(orderDetail.GetById(id));
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public ActionResult<OrderDetailModel> Post([FromBody] OrderDetailModel orderToAdd)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedOrder = orderDetail.Add(orderToAdd);
            return CreatedAtAction("Get", addedOrder, new { id = addedOrder.Orderid });
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDetailModel orderToAdd, int? productId)
        {
            if (!orderDetail.Exists(id) || !orderDetail.ProductExists(id,productId))         
            {
                return NotFound();
            }
            if(id != orderToAdd.Orderid)
            {
                return BadRequest();
            }
            orderDetail.Update(orderToAdd, productId);
            return NoContent();
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, int? productId)
        {
            if(!orderDetail.Exists(id)|| !orderDetail.ProductExists(id, productId))
            {
                return NotFound();
            }
            orderDetail.Delete(id, productId);
            return NoContent();
        }
    }
}
