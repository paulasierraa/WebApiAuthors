using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<LogHttpResponse> logger;

        public LogHttpResponse(RequestDelegate next, ILogger<LogHttpResponse> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var ms = new MemoryStream())
            {
                 var originalBody = context.Response.Body;
                    context.Response.Body = ms;
                    await next.Invoke(context);
                    ms.Seek(0, SeekOrigin.Begin);
                    string response = new StreamReader(ms).ReadToEnd();
                    ms.Seek(0, SeekOrigin.Begin);
                    await ms.CopyToAsync(originalBody);
                    context.Response.Body = originalBody;
                    logger.LogInformation(response);
             };
        }
    }
}
