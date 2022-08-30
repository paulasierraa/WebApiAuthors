using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")] 
    public class AuthorsController:ControllerBase
    {
        private readonly IAuthorService service;

        public AuthorsController(IAuthorService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<GenericResponse<IEnumerable<Author>>> GetAll()
        {
           return  await this.service.GetAll();
        }
        [HttpPost]
        public async Task<GenericResponse<Author>> CreateAsync(AuthorRequest request)
        {
            return await this.service.CreateAsync(request);
        }
        [HttpPut]
        public async Task<GenericResponse<Author>> EditAsync(Author request)
        {
            return await this.service.EditAsync(request);
        }
        [HttpDelete]
        public GenericResponse<bool> Delete(AuthorRequest request)
        {
            return this.service.Delete(request);
        }

    }
}
