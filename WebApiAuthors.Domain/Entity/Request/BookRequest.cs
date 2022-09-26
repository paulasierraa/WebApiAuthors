using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthors.DTOS
{
    public class BookRequest
    {
        public string Title { get; set; }
        public List<int> AuthorsId { get; set; }
    }
}
