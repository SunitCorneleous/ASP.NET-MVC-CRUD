using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMVC.CustomFilters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        [JsonIgnore]
        private List<string> _parameters = new List<string>();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ParameterDescriptor[] parameters = context.ActionDescriptor.GetParameters();

            var _controller = context.Controller;
            var _actionMethod = context.ActionDescriptor.ActionName;

            foreach (var item in parameters)
            {
                _parameters.Add(item.ParameterName.ToString());
            }

            var log = new
            {
                parameters = _parameters,
                contoller = _controller.ToString(),
                actionMethod = _actionMethod.ToString()
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(log);



            File.WriteAllText(@"D:\DEVELOPMENT FOLDER\C# .NET\ASP.NET-MVC-CRUD\CRUDMVC\log\log1.txt", json);
        }
    }
}