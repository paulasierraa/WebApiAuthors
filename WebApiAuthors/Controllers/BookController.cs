using AutoMapper;
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
    [Route("api/books")]
    public class BookController:ControllerBase
    {
        private ApplicationDbContext context;
        private readonly IMapper mapper;

        public BookController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> Get()
        {
            var response = await context.Books.ToListAsync();
            return mapper.Map<List<BookResponse>>(response);
        }
        [HttpPost]
        public async Task<ActionResult> Post(BookRequest book)
        {
            var data = mapper.Map<Book>(book);
            context.Add(data);
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
