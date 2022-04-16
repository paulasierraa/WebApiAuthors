using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController:ControllerBase
    {
        private ApplicationDbContext context;
        public AuthorsController(ApplicationDbContext context)
        {
            this.context=context;
        }

        [HttpGet] //api/autores
        [HttpGet("listado")] //api/autores/listado
        [HttpGet("/listado")] //listado
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await context.Authors.Include(opt=> opt.Books).ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            return await context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Author>>> GetByName(string name)
        {
            return await context.Authors.Where(x => x.Name.Contains(name)).ToListAsync();
        }
        [HttpGet("first")] 
        public async Task<ActionResult<Author>> GetFirst()
        {
            return await context.Authors.Include(opt=>opt.Books).FirstOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult>Post(Author author)
        {
            context.Add(author);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("${id:int}")] //api/authors/1
        public async Task<ActionResult>Put(Author author,[FromHeader] int id)
        {
            var exist = await context.Authors.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            if (author.Id!=id)
            {
                return BadRequest("No hay congruencia en el id del autor");
            }

            context.Update(author);
            await context.SaveChangesAsync();
            return Ok();
            
        }
        [HttpDelete("${id:int}")] //api/authors/1
        public async Task<ActionResult>Delete(int id)
        {
            var exist = await context.Authors.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound();
            }

            context.Remove(new Author() { Id = id });
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
