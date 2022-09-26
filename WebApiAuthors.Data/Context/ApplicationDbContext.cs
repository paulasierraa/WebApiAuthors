using System;
using Microsoft.EntityFrameworkCore;
using WebApiAuthors.Entity;
using WebApiAuthors.Entity.Base;

namespace WebApiAuthors.Data.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //estableciendo llaves compuestas
            modelBuilder.Entity<AuthorBooks>()
                .HasKey(al => new { al.AuthorId, al.BookId }); 
        }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<AuthorBooks> AuthorBook { get; set; }

    }
}
