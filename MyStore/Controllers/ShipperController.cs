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
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService service;
        public ShipperController(IShipperService service)
        {
            this.service = service;
        }

        // GET: api/<ShipperController>
        [HttpGet]
        public ActionResult<IEnumerable<Shipper>> GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ActionResult<Shipper> GetById(int id)
        {
            if (!service.Exists(id))
            {
                return NotFound();
            }
            return Ok(service.GetById(id));
        }
        [HttpGet("info/{id}")]
        public ActionResult<Shipper> GetInfoById(int id)
        {
            if (!service.Exists(id))
            {
                return NotFound();
            }
            return Ok(service.GetInfoById(id));
        }
            // POST api/<ShipperController>
            [HttpPost]
        public IActionResult Post([FromBody] Shipper shipperToAdd)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createShipper = service.Add(shipperToAdd);
            return CreatedAtAction("GetAll", createShipper, new { id = createShipper.Shipperid });
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Shipper shipperToUpdate)
        {
            if (id != shipperToUpdate.Shipperid)
            {
                return BadRequest();
            }
            if (!service.Exists(id))
            {
                return NotFound();
            }
            service.Update(shipperToUpdate);
            return NoContent();
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!service.Exists(id))
            {
                return NotFound();
            }
            service.Delete(id);
            return NoContent();
        }
    }
}
