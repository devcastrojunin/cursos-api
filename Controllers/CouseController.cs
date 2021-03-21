using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cursos_api.Data;
using cursos_api.Models;

namespace cursos_api.Controllers
{
    [ApiController]
    [Route("v1/courses")]
    public class CouseController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Course>>> GetAction([FromServices] DataContext context)
        {
            var courses = await context.Courses.Include(c => c.Category).ToListAsync();
            if (courses == null) { return NotFound(); }
            return Ok(courses);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Course>> GetById([FromServices] DataContext context, int id)
        {
            var course = await context.Courses.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) { return NotFound(); }
            return Ok(course);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Course>> Post([FromServices] DataContext context, [FromBody] Course model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            context.Courses.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
    }
}