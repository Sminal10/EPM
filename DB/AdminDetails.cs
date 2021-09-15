using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using EPM.Controllers;
using System.Data;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
namespace EPM.DB
{
    public class AdminDetails
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        string connectionstring = "Data Source=DESKTOP-39COJ7F\\SQLEXPRESS;Initial Catalog=EPM;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=1007";
        
        public IEnumerable<GetAdminDetails> GetAdminDetails(string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sessionKey = _session.GetString("username");
                string query = "SELECT AdminId,AdminFName,AdminLName,AdminGender,AdminPhoneNmber FROM [EPM].[dbo].[Admin] WHERE AdminUsername ='" + sessionKey + "'";
                List<GetAdminDetails> adminDetails = new List<GetAdminDetails>();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GetAdminDetails getAdminDetails = new GetAdminDetails();
                    getAdminDetails.AdminId = reader["AdminId"].ToString();
                    getAdminDetails.AdminFname = reader["AdminFName"].ToString();
                    getAdminDetails.AdminLname = reader["AdminLName"].ToString();
                    getAdminDetails.AdminGender = reader["AdminGender"].ToString();
                    getAdminDetails.AdminPhoneNumber = reader["AdminPhoneNmber"].ToString();
                    adminDetails.Add(getAdminDetails);
                }
                connection.Close();

                return adminDetails.ToArray();
            }
        }
    }
}
