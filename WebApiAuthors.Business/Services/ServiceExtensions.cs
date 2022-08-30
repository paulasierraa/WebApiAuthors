using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Business.Services.Core;
using WebApiAuthors.Business.Services.Core.Interface;

namespace WebApiAuthors.Business.Services
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICommentService, CommentService>();
        }
    }
}
