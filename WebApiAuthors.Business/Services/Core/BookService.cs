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
    public class BookService:GenericService<Book,BookRequest,BookResponse,IBookRepository>,IBookService
    {
        public BookService(IBookRepository repository , IMapper mapper):base(mapper,repository)
        {

        }
       
        
    }
}
