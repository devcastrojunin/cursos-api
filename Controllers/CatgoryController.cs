using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cursos_api.Data;
using cursos_api.Models;

namespace cursos_api.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CatgoryController: Controller
    {
        private DataContext _context;
        public CatgoryController(DataContext context){
            _context =  context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> GetAction([FromServices] DataContext context){
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromServices] DataContext context, [FromBody] Category model){
            if(!ModelState.IsValid) { return BadRequest(ModelState); }

            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return model;
        }

    }   

}