using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ApplicationDataAccess.Employee;
using Newtonsoft.Json;
using CRUDMVC.Models;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private EApplicationDAL objEApplication;

        [WebMethod]
        public string AppGetAllEmployeeData()
        {
            objEApplication = new EApplicationDAL();

            return JsonConvert.SerializeObject(objEApplication.GetAllEmployee());
        }

        [WebMethod]
        public string AppCreateNewEmployee(string data)
        {
            EmployeeModel employeeData = JsonConvert.DeserializeObject<EmployeeModel>(data);

            objEApplication = new EApplicationDAL();

            return JsonConvert.SerializeObject(objEApplication.AddNewEmployee(employeeData));
        }

        [WebMethod]
        public string AppDeleteEmployee(string data)
        {
            int id = JsonConvert.DeserializeObject<int>(data);

            objEApplication = new EApplicationDAL();

            return JsonConvert.SerializeObject(objEApplication.DeleteEmployee(id));
        }
        [WebMethod]
        public string AppUpdateEmployee(string idData, string employeeData)
        {
            int id = JsonConvert.DeserializeObject<int>(idData);
            EmployeeModel employee = JsonConvert.DeserializeObject<EmployeeModel>(employeeData);

            objEApplication = new EApplicationDAL();

            return JsonConvert.SerializeObject(objEApplication.UpdateEmployee(id, employee));
        }

        [WebMethod]
        public string AppGetEmployee(string data)
        {
            int id = JsonConvert.DeserializeObject<int>(data);

            objEApplication = new EApplicationDAL();

            return JsonConvert.SerializeObject(objEApplication.GetEmployee(id));
        }
    }
}
