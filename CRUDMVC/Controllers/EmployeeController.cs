using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDMVC.DataAccessLayer;
using CRUDMVC.Models;


namespace CRUDMVC.Controllers
{
    public class EmployeeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployeeData()
        {
            DAL dal = new DAL();

            var js = new
            {
                data = dal.GetAllEmployee(),
                message = "",
                success = true
            };

            var result = this.Json(js, JsonRequestBehavior.AllowGet);

            return result;
        }

        [HttpPost]
        public JsonResult CreateEmployee(EmployeeModel emodel)
        {
            DAL dal = new DAL();

            var js = new
            {
                data = "",
                message = "",
                success = dal.AddNewEmployee(emodel)
            };

            var response = this.Json(js, JsonRequestBehavior.AllowGet);

            return response;
        }

        [HttpPost]
        public JsonResult DeleteEmployee(string id)
        {
            DAL dal = new DAL();

            var js = new
            {
                data = "",
                message = "",
                success = dal.DeleteEmployee(int.Parse(id))
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

        public ActionResult AddEmployee()
        {
            return View();
        }
    }
}