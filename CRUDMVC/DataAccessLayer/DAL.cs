using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using CRUDMVC.Models;

namespace CRUDMVC.DataAccessLayer
{
    public class DAL : Controller
    {

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        // Get All Employee
        public List<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> lst = new List<EmployeeModel>();

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                EmployeeModel employee = new EmployeeModel();

                employee.EmployeeId = Convert.ToInt32((rdr["EmployeeId"]).ToString());
                employee.Name = rdr["Name"].ToString();
                employee.Email = rdr["Email"].ToString();
                employee.Address = rdr["Address"].ToString();
                employee.Position = rdr["Position"].ToString();

                lst.Add(employee);
            }

            rdr.Close();
            con.Close();

            return lst;
        }

        // Add An Employee
        public bool AddNewEmployee(EmployeeModel employeeModel)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Employee(Name, Email, Address, Position) VALUES (@Name, @Email, @Address, @Position)", con);

            cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
            cmd.Parameters.AddWithValue("@Email", employeeModel.Email);
            cmd.Parameters.AddWithValue("@Address", employeeModel.Address);
            cmd.Parameters.AddWithValue("@Position", employeeModel.Position);

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i == 1)
                return true;
            else
                return false;
        }

        // Delete An Employee
        public bool DeleteEmployee(int id)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE EmployeeId = @EmployeeId", con);

            cmd.Parameters.AddWithValue("@EmployeeId", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Update An Employee
        public bool UpdateEmployee(int id, EmployeeModel employeeData)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Employee SET Name = @Name, Email = @Email, Address = @Address, Position = @Position WHERE EmployeeId = @Id", con);

            cmd.Parameters.AddWithValue("@Name", employeeData.Name);
            cmd.Parameters.AddWithValue("@Email", employeeData.Email);
            cmd.Parameters.AddWithValue("@Address", employeeData.Address);
            cmd.Parameters.AddWithValue("@Position", employeeData.Position);
            cmd.Parameters.AddWithValue("@Id", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Get Employee By Id
        public EmployeeModel GetEmployee(int id)
        {
            EmployeeModel employee = new EmployeeModel();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE EmployeeId = @Id;", con);

            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                employee.EmployeeId = Convert.ToInt32((rdr["EmployeeId"]).ToString());
                employee.Name = rdr["Name"].ToString();
                employee.Email = rdr["Email"].ToString();
                employee.Address = rdr["Address"].ToString();
                employee.Position = rdr["Position"].ToString();
            }

            rdr.Close();
            con.Close();

            return employee;
        }
    }
}
