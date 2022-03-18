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
            /* 
             finds all order details( id )
             the model that you want to update ( order to add )
             
            And here the fun begin

            You can update the val of an index in two ways : 1) you ignore the ?productId and the index will be automatically orderToAdd.ProductId
                                                             2) you can put the productId of the OrderDetail that you want to change 

            OrderDetailPresentation was created to create more space for the OrderDetailService 
            The code in OrderDetailService and Repository is bad , because it's hard to read , and the logic behind it is somewhat ok
            
             
             */
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
        {/* 
            finds all order details( id )
            the delete will remove the first index by default
            if you want to delete a specified item, then at the prductId type the product Id that you want to delete             
             */
            if (!orderDetail.Exists(id)|| !orderDetail.ProductExists(id, productId))
            {
                return NotFound();
            }
            orderDetail.Delete(id, productId);
            return NoContent();
        }
    }
}
