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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryPresentation category;

        public CategoryController(ICategoryPresentation category)
        {
            this.category = category;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> Get()
        {
            return Ok(category.GetAll());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CategoryProductsModel>> GetById(int id)
        {
            if(!category.Exists(id))
            {
                return NotFound();
            }
            return Ok(category.GetById(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryModel categoryToAdd)
        {
            if (!ModelState.IsValid || category.Exists(categoryToAdd.Categoryid))
            {
                return BadRequest();
            }
            var createdCategory = category.Add(categoryToAdd);
            return CreatedAtAction("Get", createdCategory, new { id = createdCategory.Categoryid });
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryModel categoryToUpdate)
        {
            if(!category.Exists(id))
            {
                return NotFound();
            }
            if (id != categoryToUpdate.Categoryid)
            {
                return BadRequest();
            }
            category.Update(categoryToUpdate);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!category.Exists(id))
            {
                return NotFound();
            }
            category.Delete(id);
            return NoContent();
        }
    }
}
