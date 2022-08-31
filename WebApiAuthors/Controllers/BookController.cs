using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Core.Interface;
using WebApiAuthors.Domain.Entity.Response;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController:ControllerBase
    {

        private readonly IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<GenericResponse<IEnumerable<Book>>> GetAll()
        {
            return await this.service.GetAll();
        }
        [HttpPost]
        public async Task<GenericResponse<Book>> CreateAsync(BookRequest request)
        {
            return await this.service.CreateAsync(request);
        }
        [HttpPut]
        public async Task<GenericResponse<Book>> EditAsync(Book request)
        {
            return await this.service.EditAsync(request);
        }
        [HttpDelete]
        public GenericResponse<bool> Delete(BookRequest request)
        {
            return this.service.Delete(request);
        }

    }
}
