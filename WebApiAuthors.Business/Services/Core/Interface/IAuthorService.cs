using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Interfaces;
using WebApiAuthors.Data.Repositories.Core.Interfaces;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Business.Services.Core.Interface
{
    public interface IAuthorService:IGenericService<Author,AuthorRequest,AuthorResponse,IAuthorRepository>
    {
    }
}
