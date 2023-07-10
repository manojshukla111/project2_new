using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data; // Assuming your DbContext class is named "MyDbContext"
using WebApplication2.model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // inherit control base class here 
    public class HomeController : ControllerBase
    {
        // private accesing base_db_context class 
        private readonly base_db_context_class new_dbContext; // Replace with your DbContext class name

        public HomeController(base_db_context_class dbContext)
        {
            // setting the value of varivale  
            new_dbContext = dbContext;
        }
        // to get the data 

        [HttpGet]
        public IActionResult Get()
        {
            var results = new_dbContext.mytable.ToList();
            return Ok(results);
        }

        [HttpPost]
        // to post the data in mytable
        public IActionResult Post([FromBody] my_model model)
        {
            new_dbContext.mytable.Add(model);
            new_dbContext.SaveChanges();
            return Ok("Record created successfully");
        }
        // to update the value using id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] my_model model)
        {
            var existingModel = new_dbContext.mytable.Find(id);
            if (existingModel == null)
                return NotFound("Record not found");

            existingModel.name = model.name;
            existingModel.subject = model.subject;
            new_dbContext.SaveChanges();

            return Ok("Record updated successfully");
        }
        // to delete the data using id  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingModel = new_dbContext.mytable.Find(id);
            if (existingModel == null)
                return NotFound("Record not found");

            new_dbContext.mytable.Remove(existingModel);
            new_dbContext.SaveChanges();

            return Ok("Record deleted successfully");
        }
    }
}
