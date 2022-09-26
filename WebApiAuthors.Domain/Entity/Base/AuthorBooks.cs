using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthors.Entity.Base
{
    public class AuthorBooks
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int Order { get; set; } //determinate author's order
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
