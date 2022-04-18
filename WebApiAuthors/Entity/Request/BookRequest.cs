using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthors.DTOS
{
    public class BookRequest
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }

    }
}
