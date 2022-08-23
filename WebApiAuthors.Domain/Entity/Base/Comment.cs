﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthors.Entity.Base
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; } 
   
    }
}
