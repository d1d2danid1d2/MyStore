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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            var productList = productService.GetAllProducts();
            return productList;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            var productById = productService.GetById(id);
            return productById;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel newProduct)
        {
            //fail fast == return;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedProduct = productService.AddProduct(newProduct);

            return CreatedAtAction("Get", addedProduct, new { id = addedProduct.Productid });


        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
