using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthors.Entity.Request
{
    public class CommentRequest
    {
        public string Content { get; set; }

        public int BookId { get; set; }
    }
}
