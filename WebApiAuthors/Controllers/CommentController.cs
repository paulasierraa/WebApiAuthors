using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;

namespace WebApiAuthors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CommentController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}")]
        public async Task <ActionResult<List<CommentResponse>>> GetByBook(int id)
        {
            var comments = await context.Comments.Where(comment => comment.BookId == id).ToListAsync();

            return mapper.Map<List<CommentResponse>>(comments);
        }
        [HttpPost]
        public async Task<ActionResult> Post(CommentRequest commentRequest)
        {
            var existBook = await context.Books.AnyAsync(book => book.Id == commentRequest.BookId);
            if (!existBook)
            {
                return NotFound("El libro no existe");
            }
            var comment = mapper.Map<Comment>(commentRequest);
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
