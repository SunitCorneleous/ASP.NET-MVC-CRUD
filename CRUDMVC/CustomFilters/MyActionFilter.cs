using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMVC.CustomFilters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ParameterDescriptor[] parameters = context.ActionDescriptor.GetParameters();

            var _controller = context.Controller;
            var _actionMethod = context.ActionDescriptor.ActionName;
        }
    }
}