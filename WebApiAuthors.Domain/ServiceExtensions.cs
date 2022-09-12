using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiAuthors.Domain.Filters;

namespace WebApiAuthors.Domain
{
    public static class ServiceExtensions
    {
        public static void AddDomainExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ActionFilter>();
        }
    }
}
