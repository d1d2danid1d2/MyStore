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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeModel>> GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeModel> GetById(int id)
        {
            return Ok(service.GetById(id));
        }
        [HttpGet("info/{id}")]
        public ActionResult<Employee> GetInfoById(int id)
        {
            return Ok(service.GetInfoById(id));
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel employeeToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addedEmployee = service.Add(employeeToAdd);
            return CreatedAtAction("GetAll", addedEmployee, new { id = addedEmployee.Empid });
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeModel employeeToUpdate)
        {
            if(id != employeeToUpdate.Empid)
            {
                return BadRequest();
            }
            if (!service.Exists(id))
            {
                return NotFound();
            }
            service.Update(employeeToUpdate);
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.Exists(id))
            {
                return NotFound();
            }
            service.Delete(id);
            return NoContent();
        }
    }
}
