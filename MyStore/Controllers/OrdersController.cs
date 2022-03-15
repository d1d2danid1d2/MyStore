using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;
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
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderModel>> GetAll(string? city, Shippers shipper,[FromQuery]List<string>? country)
        {//1 shipCity ->
            var order = orderService.GetAll(city, shipper, country);
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
            return CreatedAtAction("GetAll", new { id = addOrder.Orderid },mapper.Map<OrderModel>(addOrder));
            //var newTestOrder = new Order()
            //{
            //    Orderdate = DateTime.Now,
            //    Shipaddress = "random adress",
            //    Shipcity = "random city",
            //    Shipcountry = "country",
            //    Shippostalcode = "707",
            //    Custid = 85,
            //    Shipperid = 3,
            //    Empid = 5,
            //    Freight = 12.5M,
            //    Shipname = "delivery",
            //    Requireddate = DateTime.Now.AddDays(3)
            //};

            //var orderDetailList = new List<OrderDetail>();
            //var product1 = new OrderDetail()
            //{
            //    Productid = 22,
            //    Discount = 0,
            //    Qty = 2,
            //    Unitprice = 22
            //};
            //orderDetailList.Add(product1);
            //var product2 = new OrderDetail()
            //{
            //    Productid = 57,
            //    Discount = 0,
            //    Qty = 12,
            //    Unitprice = 7
            //};
            //orderDetailList.Add(product2);
            //newTestOrder.OrderDetails = orderDetailList;
            //var updatedOrder = orderService.AddNewOrder(newTestOrder);


            //var updatedProduct = orderService.AddOrder(newOrder);
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
            if (!orderService.Exists(id))
            {
                return NotFound();
            }
            orderService.Delete(id);
            return NoContent();
        }
    }
}
