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
    [Route("api/books")]
    public class BookController:ControllerBase
    {
        private ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return await context.Books.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            context.Add(book);
            await context.SaveChangesAsync();
            return Ok(); 
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult>Put(Book book, int id)
        {
            var exist = await context.Books.AnyAsync(x => x.Id ==id);
            if(!exist)
            {
                return NotFound();
            }
            context.Update(book);
            await context.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult>Delete(int id)
        {
            var exist = await context.Books.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound();
            }
            context.Remove(new Author { Id = id });
            return Ok();
        }
    }
}
