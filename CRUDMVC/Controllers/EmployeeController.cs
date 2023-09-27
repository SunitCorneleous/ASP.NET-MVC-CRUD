using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDMVC.CustomFilters;
using CRUDMVC.DataAccessLayer;
using CRUDMVC.Models;
using Newtonsoft.Json;


namespace CRUDMVC.Controllers
{
    public class EmployeeController : Controller
    {
        CRUDMVC.WebServiceReference.WebService1SoapClient webRef;

        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public JsonResult GetEmployeeData()
        {
            webRef = new CRUDMVC.WebServiceReference.WebService1SoapClient();

            string data = webRef.AppGetAllEmployeeData();

            List<EmployeeModel> modelList = JsonConvert.DeserializeObject<List<EmployeeModel>>(data);

            var js = new
            {
                data = modelList,
                message = "",
                success = true
            };

            var result = this.Json(js, JsonRequestBehavior.AllowGet);

            return result;
        }

        [MyActionFilter]
        [HttpPost]
        public JsonResult CreateEmployee(EmployeeModel emodel)
        {
            webRef = new CRUDMVC.WebServiceReference.WebService1SoapClient();

            var js = new
            {
                data = "",
                message = "",
                success = webRef.AppCreateNewEmployee(JsonConvert.SerializeObject(emodel))
            };

            var response = this.Json(js, JsonRequestBehavior.AllowGet);

            return response;
        }

        [MyActionFilter]
        [HttpPost]
        public JsonResult DeleteEmployee(string id)
        {
            webRef = new CRUDMVC.WebServiceReference.WebService1SoapClient();

            var js = new
            {
                data = "",
                message = "",
                success = webRef.AppDeleteEmployee(JsonConvert.SerializeObject(int.Parse(id)))
            };

            var response = this.Json(js, JsonRequestBehavior.AllowGet);

            return response;
        }

        [MyActionFilter]
        [HttpPost]
        public JsonResult UpdateEmployee(string id, EmployeeModel data)
        {
            webRef = new CRUDMVC.WebServiceReference.WebService1SoapClient();

            var js = new
            {
                data = "",
                message = "",
                success = webRef.AppUpdateEmployee(JsonConvert.SerializeObject(int.Parse(id)), JsonConvert.SerializeObject(data))
            };

            var response = this.Json(js, JsonRequestBehavior.AllowGet);

            return response;
        }

        [HttpGet]
        public JsonResult GetEmployeeById(string id)
        {
            webRef = new CRUDMVC.WebServiceReference.WebService1SoapClient();

            var js = new
            {
                data = webRef.AppGetEmployee(JsonConvert.SerializeObject(int.Parse(id))),
                message = "",
                success = true
            };

            var result = this.Json(js, JsonRequestBehavior.AllowGet);

            return result;
        }
    }
}