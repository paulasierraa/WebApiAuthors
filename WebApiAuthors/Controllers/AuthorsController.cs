using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthorsController:ControllerBase
    {
        private ApplicationDbContext context;
        private readonly IMapper mapper;

        public AuthorsController(ApplicationDbContext context,IMapper mapper)
        {
            this.context=context;
            this.mapper = mapper;
        }

        [HttpGet] //api/autores
        //[HttpGet("listado")] //api/autores/listado
        //[HttpGet("/listado")] //listado
        public async Task<ActionResult<List<AuthorResponse>>> Get()
        {
            var result = await context.Authors.Include(opt => opt.Books).ToListAsync();
            return mapper.Map<List<AuthorResponse>>(result);
        }
        [HttpGet("NoAsync")] //listado
        public List<AuthorResponse> GetNoAsync()
        {
            var result = context.Authors.Include(opt => opt.Books).ToList();
            return mapper.Map<List<AuthorResponse>>(result);
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
        public async Task<ActionResult>Post([FromBody] AuthorRequest author)
        {
            var data = mapper.Map<Author>(author);
            context.Add(data);
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
