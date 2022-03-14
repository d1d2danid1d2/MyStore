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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService category;
        public CategoryController(ICategoryService category)
        {
            this.category = category;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            return Ok(category.GetAll());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            if(!category.Exists(id))
            {
                return NotFound();
            }
            return Ok(category.GetById(id));
        }
        [HttpGet("info/{id}")]
        public ActionResult<Category> GetInfoById(int id)
        {
            if (!category.Exists(id))
            {
                return NotFound();
            }
            return Ok(category.GetInfoById(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category categoryToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedCategory = category.Add(categoryToAdd);
            return CreatedAtAction("GetAll", addedCategory, new { id = addedCategory.Categoryid });
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category updateCategory)
        {
            if(id != updateCategory.Categoryid)
            {
                return BadRequest();
            }
            if (!category.Exists(id))
            {
                return NotFound();
            }
            category.Update(updateCategory);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!category.Exists(id))
            {
                return NotFound();
            }
            category.Delete(id);
            return NoContent();
        }
    }
}
