using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;
using WebApiAuthors.Business.Services;
using WebApiAuthors.Data;
using WebApiAuthors.Domain.Context;
using WebApiAuthors.Middlewares;
using WebApiAuthors.Utils.Mapper;

namespace WebApiAuthors
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options  => 
                options.UseSqlServer(
                Configuration.GetConnectionString("defaultConnection")    
            ));

            services.AddRepositoryExtensions(Configuration);
            services.AddServiceExtensions(Configuration);

            //  services.AddTransient<ActionFilter>;
            //servicios de caché
            services.AddResponseCaching();
            //servicios de autenticación
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiAuthors", Version = "v1" });
            });
            services.AddAutoMapper(typeof(AutoMapperProfiles));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup>logger)
        {
            app.Use(async (context,next)=> {
                using(var ms = new MemoryStream())
                {
                    var originalBody = context.Response.Body;
                    context.Response.Body = ms;
                    await next.Invoke();

                    ms.Seek(0, SeekOrigin.Begin);
                    string response = new StreamReader(ms).ReadToEnd();
                    ms.Seek(0, SeekOrigin.Begin);
                    await ms.CopyToAsync(originalBody);
                    context.Response.Body = originalBody;
                    logger.LogInformation(response);
                }
            });
            /*Middleware para ruta específica*/
            app.Map("/ruta1", app =>
             {
                app.Run(async contexto =>
                {
                    await contexto.Response.WriteAsync("Intercepción tubería");
                
                });
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiAuthors v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //caché
            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
