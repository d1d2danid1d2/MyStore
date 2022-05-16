using Microsoft.AspNetCore.Mvc;
using MyStore.DataPresentation;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeePresentation presentation;
        public EmployeeController(IEmployeePresentation presentation)
        {
            this.presentation = presentation;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeModel>> GetAll()
        {
            return Ok(presentation.GetAll());
            
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeModel> GetById(int id)
        {
            return Ok(presentation.GetById(id));
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel employeeToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedEmployee = presentation.Add(employeeToAdd);
            return CreatedAtAction("GetAll", addedEmployee, new { id = addedEmployee.Empid });
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeModel employeeToUpdate)
        {
            if (id != employeeToUpdate.Empid)
            {
                return BadRequest();
            }
            if (!presentation.Exists(id))
            {
                return NotFound();
            }
            presentation.Update(employeeToUpdate);
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
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