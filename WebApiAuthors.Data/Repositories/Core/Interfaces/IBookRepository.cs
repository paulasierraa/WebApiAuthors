using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.Repositories.IGenericRepository;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Data.Repositories.Core.Interfaces
{
    public interface IBookRepository:IGenericRepository<Book,BookRequest,BookResponse>
    {
    }
}
