using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.DTOS;
using WebApiAuthors.Entity;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Entity.Request;
using WebApiAuthors.Entity.Response;

namespace WebApiAuthors.Utils.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AuthorRequest, Author>();
            CreateMap<Author, AuthorResponse>();

            CreateMap<BookRequest, Book>()
                .ForMember(book=> book.AuthorBooks, 
                            options=> options.MapFrom(MapAuthorsBooks)           
                      );
                
            CreateMap<Book, BookResponse>();

            CreateMap<CommentRequest, Comment>();
            CreateMap<Comment, CommentResponse>();


       }
    /*
     *  This method allow to set List<int> authorId to List<AuthorBooks> AuthorId propierty
        @bookRequest  
        @book 
    */
    private List<AuthorBooks> MapAuthorsBooks(BookRequest bookRequest,Book book)
    {
        var result = new List<AuthorBooks>();
        if(bookRequest.AuthorsId==null)
        {
            return result;
        }

        foreach (var authorId in bookRequest.AuthorsId)
        {
            result.Add(new AuthorBooks() { AuthorId = authorId });
        }

       return result;
    }
    }
}
