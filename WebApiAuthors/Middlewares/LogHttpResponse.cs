using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthors.Middlewares
{
    public static class LogHttpResponseExtensions
    {
        public static IApplicationBuilder UseLogHttpResponse(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogHttpResponse>();
        }
    }
    public class LogHttpResponse
    {
        private readonly RequestDelegate next;

        public LogHttpResponse(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var ms = new MemoryStream())
            {
                var bodyOriginal = context.Response.Body;
                context.Response.Body = ms;
                await next(context); //la tubería continúa

                ms.Seek(0, SeekOrigin.Begin);
                string response = new StreamReader(ms).ReadToEnd();

                ms.Seek(0, SeekOrigin.Begin);
                await ms.CopyToAsync(bodyOriginal);
                context.Response.Body = bodyOriginal;
                Console.WriteLine(response);

             };
        }
    }
}
