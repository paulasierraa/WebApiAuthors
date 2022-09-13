using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Core.Interface;
using WebApiAuthors.Domain.Entity.Response;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;

namespace WebApiAuthors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<GenericResponse<IEnumerable<Comment>>> GetAll()
        {
            return await this.service.GetAll();
        }
        [HttpGet("{id:int}")]
        public async Task<GenericResponse<List<CommentResponse>>> GetById(int id)
        {
            return await this.service.GetCommentByBook(id);
        }
        [HttpPost]
        public async Task<GenericResponse<Comment>> CreateAsync(CommentRequest request)
        {
            return await this.service.CreateAsync(request);
        }
        [HttpPut]
        public async Task<GenericResponse<Comment>> EditAsync(Comment request)
        {
            return await this.service.EditAsync(request);
        }
        [HttpDelete]
        public GenericResponse<bool> Delete(CommentRequest request)
        {
            return this.service.Delete(request);
        }

    }
}
