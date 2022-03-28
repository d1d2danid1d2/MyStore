using Microsoft.AspNetCore.Mvc;
using MyStore.DataPresentation;
using MyStore.Domain.Entities;
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
    public class ShipperController : ControllerBase
    {
        private readonly IShipperPresentation presentation;

        public ShipperController(IShipperPresentation presentation)
        {
            this.presentation = presentation;
        }
        // GET: api/<ShipperController>
        [HttpGet]
        public ActionResult<IEnumerable<ShipperModel>> Get()
        {
            return Ok(presentation.GetAll());
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ActionResult<ShipperModel> GetById(int id)
        {
            if (!presentation.Exists(id))
            {
                return NotFound();
            }
            return Ok(presentation.GetById(id));
        }

        // POST api/<ShipperController>
        [HttpPost]
        public ActionResult<ShipperModel> Post([FromBody] ShipperModel toAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var shipperToAdd = presentation.Add(toAdd);
            return CreatedAtAction("Get", shipperToAdd, new { id = shipperToAdd.Shipperid });
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShipperModel toUpdate)
        {
            if(id != toUpdate.Shipperid)
            {
                return BadRequest();
            }
            if(!presentation.Exists(id))
            {
                return NotFound();
            }
            presentation.Update(toUpdate);
            return NoContent();
        }

        // DELETE api/<ShipperController>/5
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
