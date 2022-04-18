using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;

namespace WebApiAuthors.Utils.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AuthorRequest, Author>();
            CreateMap<Author, AuthorResponse>();

            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookResponse>();
        }
    }
}
