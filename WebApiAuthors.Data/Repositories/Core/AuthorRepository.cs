using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.GenericRepository;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
using WebApiAuthors.Data.Context;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Data.Repositories.Core
{
    public class AuthorRepository:GenericRepository<Author,AuthorRequest,AuthorResponse>,IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper)
        {
        }
    }
}
