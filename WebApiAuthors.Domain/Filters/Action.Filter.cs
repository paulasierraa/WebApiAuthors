using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApiAuthors.Filters
{
    public class Action : IActionFilter
    {
        public ILogger<Action> Logger { get; }

        public Action(ILogger<Action> logger)
        {
            Logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("Antes de ejecutar la acción");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

    
    }
}
