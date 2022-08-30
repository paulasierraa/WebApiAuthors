using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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
            //servicios de cach�
            services.AddResponseCaching();
            //servicios de autenticaci�n
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiAuthors", Version = "v1" });
            });
            services.AddAutoMapper(typeof(AutoMapperProfiles));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //se ejecuta siempre
            //app.Run(async contexto => {
            //    await contexto.Response.WriteAsync("Estoy interceptando la tuber�a");
            //});

            //intercepta cierta ruta
            //app.Map("/ruta1", app =>
            //{
            //    app.Run(async contexto =>
            //    {
            //        await contexto.Response.WriteAsync("Estoy interceptando la tuber�a");
            //    });
            //}); 
            //app.UseLogHttpResponse();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiAuthors v1"));
            }

 

            app.UseHttpsRedirection();

            app.UseRouting();

            //cach�
            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
