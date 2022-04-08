using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAuthors.Entity;

namespace WebApiAuthors
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public static implicit operator ControllerContext(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}
