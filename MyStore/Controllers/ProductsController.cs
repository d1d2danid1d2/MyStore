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
    public class ProductsController : ControllerBase
    {
        private readonly IProductPresentation presentation;

        public ProductsController(IProductPresentation presentation)
        {
            this.presentation = presentation;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductsPresentationModel>> Get()
        {
            return Ok(presentation.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProductModel>> GetById(int id)
        {
            if(!presentation.Exists(id))
            { 
                return NotFound();
            }
            return Ok(presentation.GetById(id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductsPresentationModel product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdProduct = presentation.Add(product);
            return CreatedAtAction("Get", createdProduct, new { id = createdProduct.Productid });
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductsPresentationModel product)
        {
            if (!presentation.Exists(id))
            {
                return NotFound();
            }
            if(id != product.Productid)
            {
                return BadRequest();
            }
            presentation.Update(product);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
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
