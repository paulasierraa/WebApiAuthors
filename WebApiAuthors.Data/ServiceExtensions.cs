using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Data.Repositories.Core;
using WebApiAuthors.Data.Repositories.Core.Interfaces;

namespace WebApiAuthors.Data
{
    public static class ServiceExtensions
    {
        public static void AddRepositoryExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }
    }
}
