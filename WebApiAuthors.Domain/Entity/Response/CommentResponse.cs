using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.DTOS;

namespace WebApiAuthors.Entity.Response
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public BookResponse Book { get; set; }
    }
}
