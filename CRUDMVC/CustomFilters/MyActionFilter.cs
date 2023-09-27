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
            //{System.Web.Mvc.ReflectedParameterDescriptor}
            ParameterDescriptor[] parameters = context.ActionDescriptor.GetParameters(); 
        }
    }
}