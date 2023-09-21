using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpPost]
        public JsonResult UpdateEmployee(string id, EmployeeModel data)
        {
            DAL dal = new DAL();

            var js = new
            {
                data = "",
                message = "",
                success = dal.UpdateEmployee(int.Parse(id), data)
            };

            var response = this.Json(js, JsonRequestBehavior.AllowGet);

            return response;
        }

        [HttpGet]
        public JsonResult GetEmployeeById(string id)
        {

            DAL dal = new DAL();

            var js = new
            {
                data = dal.GetEmployee(int.Parse(id)),
                message = "",
                success = true
            };

            var result = this.Json(js, JsonRequestBehavior.AllowGet);

            return result;
        }

        public ActionResult AddEmployee()
        {
            return View();
        }
    }
}