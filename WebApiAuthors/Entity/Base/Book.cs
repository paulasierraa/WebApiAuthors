using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.Entity.Base;

namespace WebApiAuthors.Entity
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int AuthorId { get; set; }

        public Author Author{get;set;}
        public List<Comment> Comments { get; set; }
    }
}
