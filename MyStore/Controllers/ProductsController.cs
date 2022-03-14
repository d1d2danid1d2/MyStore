using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAll()
        {
            var productList = productService.GetAll();
            return Ok(productList);
        }

        // GET: api/products/id
        [HttpGet("{id}")]
        public ActionResult<ProductModel> GetById(int id)
        {
            if(!productService.Exists(id))
            {
                return NotFound();
            }    
            return Ok(productService.GetById(id));
        }

        // GET: api/products/info/id
        [HttpGet("info/{id}")]
        public ActionResult<IEnumerable<Product>> GetInfoById(int id)
        {
            if (!productService.Exists(id))
            {
                return NotFound();
            }
            return Ok(productService.GetInfoById(id));
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel newProduct)
        {
            //fail fast == return;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedProduct = productService.Add(newProduct);
            return CreatedAtAction("GetAll", addedProduct, new { id = addedProduct.Productid });
        }

        // PUT: api/products/id
        [HttpPut("{id}")]       
        public IActionResult Put(int id, [FromBody] ProductModel productToUpdate)
        {
            //exist by id
            if(id != productToUpdate.Productid)
            {
                return BadRequest();
            }
            if (!productService.Exists(id))
            {
                return NotFound();
            }
            productService.Update(productToUpdate);
            return NoContent();            
        }

        // DELETE: api/products/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!productService.Exists(id))
            {
                return NotFound();
            }
            productService.Delete(id);
            return NoContent();
            //search the object with the id
            //delete the object
            //return no content
        }
    }
}
