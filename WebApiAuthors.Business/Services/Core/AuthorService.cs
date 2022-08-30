using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Core.Interface;
using WebApiAuthors.Business.Services.Generic;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Business.Services.Core
{
    public class AuthorService:GenericService<Author, AuthorRequest, AuthorResponse, IAuthorRepository>,IAuthorService
    {
        public AuthorService(IAuthorRepository Repository, IMapper mapper):base(mapper, Repository)
        {
        }
    }
}
