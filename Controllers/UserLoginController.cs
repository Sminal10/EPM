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
    public class UserLoginController : Controller
    {
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginIndex(LoginClass lc)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-39COJ7F\\SQLEXPRESS;Initial Catalog=EPM;Integrated Security=True");

            string sqlquery = "SELECT EmpUsername,EmpPassword FROM [dbo].[Employee] WHERE EmpUsername = @EmpUsername AND EmpPassword = @EmpPassword";

            sqlConnection.Open();
            if(sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@EmpUsername", lc.UserName);
            sqlCommand.Parameters.AddWithValue("@EmpPassword", lc.Password);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                HttpContext.Session.SetString("username", lc.UserName.ToString());
                TempData["username"] = lc.UserName;

                return RedirectToAction("Welcome");
            }
            else
            {
                ViewData["Message"] = "Employee Login Details Failed";
            }
            sqlConnection.Close();
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("RedirectLogout");
            }
            return RedirectToAction("RedirectLogout");

        }


        [ActionName("RedirectLogout")]
        public ActionResult RedirectLogout()
        {
            return View();
        }
    }
}
