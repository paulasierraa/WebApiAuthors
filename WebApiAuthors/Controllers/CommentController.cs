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
        public CommentController()
        {
        }

    }
}
