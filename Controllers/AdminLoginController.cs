using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EPM.Controllers
{
    public class AdminLoginController : Controller
    {
        public ActionResult AdminLoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLoginIndex(AdminLoginClass adlc)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-39COJ7F\\SQLEXPRESS;Initial Catalog=EPM;Integrated Security=True");

            string sqlquery = "SELECT AdminUsername,AdminPassword FROM [dbo].[Admin] WHERE AdminUsername = @AdminUsername AND AdminPassword = @AdminPassword";

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@AdminUsername", adlc.AdminUserName);
            sqlCommand.Parameters.AddWithValue("@AdminPassword", adlc.AdminPassword);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                HttpContext.Session.SetString("username", adlc.AdminUserName.ToString());
                TempData["username"] = adlc.AdminUserName.ToString();

                return RedirectToAction("AdminDashboard");
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed";
            }
            sqlConnection.Close();
            return View();
        }

        public ActionResult WelcomeAdmin()
        {

            return View();
        }
        
        // Admin Dashboard
        public ActionResult AdminDashboard()
        {

            return View();
        }

        // Add New Employee by Admin
        public ActionResult AddNewEmployee()
        {
            return View();
        }

        // Getting all Employee
        public ActionResult GetAllEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("RedirectLogout");
            }
            return RedirectToAction("RedirectLogout");
        }

        [ActionName("RedirectAdminLogout")]
        public ActionResult RedirectAdminLogout()
        {
            return View();
        }

        public ActionResult TestForm()
        {
            return View();
        }

    }
}
