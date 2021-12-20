using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPM.DB
{
    public class DBAdminLogin
    {
        //GET All
        public IEnumerable<ModelAdminDetail> GetallAdmins(string ConnectionString)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                List<ModelAdminDetail> details = new List<ModelAdminDetail>();
                SqlCommand command = new SqlCommand("uspMAdminLoginDetail", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = 0;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "AMD";
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ModelAdminDetail model = new ModelAdminDetail();
                    model.Fname = read["FName"].ToString();
                    model.Mname = read["MName"].ToString();
                    model.Lname = read["LName"].ToString();
                    model.Gender = read["Gender"].ToString();
                    model.MNumber = read["MobileNmber"].ToString();
                    model.AltNumber = read["AlternateNmber"].ToString();
                    details.Add(model);
                }
                connection.Close();
                return details.ToArray();
            }
        }

        //GET All By Id
        public IEnumerable<ModelAdminDetail> GetSingleAdmin(string username, string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                List<ModelAdminDetail> adminDetails = new List<ModelAdminDetail>();
                SqlCommand comd = new SqlCommand("uspMAdminLoginDetail", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@AdminUserName", username);
                comd.Parameters.AddWithValue("@Type", "AMD");
                SqlDataReader reader = comd.ExecuteReader();
                while (reader.Read())
                {
                    ModelAdminDetail detail = new ModelAdminDetail();
                    detail.Fname = reader["FName"].ToString();
                    detail.Mname = reader["MName"].ToString();
                    detail.Lname = reader["LName"].ToString();
                    detail.Gender = reader["Gender"].ToString();
                    detail.MNumber = reader["MobileNmber"].ToString();
                    detail.AltNumber = reader["AlternateNmber"].ToString();
                    adminDetails.Add(detail);
                }
                con.Close();
                return adminDetails.ToArray();
            }
        }
    }
}
