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
        public AuthorsController()
        {

        }

    }
}
