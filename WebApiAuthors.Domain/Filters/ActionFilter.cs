using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiAuthors.Domain.Filters
{
    public class ActionFilter : IActionFilter
    {
        public ILogger<ActionFilter> Logger { get; }

        public ActionFilter(ILogger<ActionFilter> logger)
        {
            Logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.LogInformation("Antes de ejecutar la acción");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Logger.LogInformation("Después de ejecutar la acción");
        }
    }
}
