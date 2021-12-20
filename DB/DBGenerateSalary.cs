using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPM.DB
{
    public class DBGenerateSalary
    {
        public IEnumerable<ModelGS> GetGetInf(string username, string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                List<ModelGS> adminDetails = new List<ModelGS>();
                SqlCommand comd = new SqlCommand("uspGenerateSalary", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@usrname", username);
                comd.Parameters.AddWithValue("@Type", "GS");
                SqlDataReader reader = comd.ExecuteReader();
                while (reader.Read())
                {
                    ModelGS detail = new ModelGS();
                    detail.Empid = reader["EmpId"].ToString();
                    detail.Fname = reader["FName"].ToString();
                    detail.Mname = reader["MName"].ToString();
                    detail.Lname = reader["LName"].ToString();
                    detail.Adcnum = reader["AdhaarCardNum"].ToString();
                    detail.Pannum = reader["PanCardNum"].ToString();
                    detail.BnkAcc = reader["BnkAccNo"].ToString();
                    detail.BnkBr = reader["BnkBranch"].ToString();
                    detail.BnkIfsc = reader["BnkIFSC"].ToString();
                    detail.salary = reader["Salary"].ToString();

                    adminDetails.Add(detail);
                }
                con.Close();
                return adminDetails.ToArray();
            }
        }

        //GET Saved Salary
        public IEnumerable<ModelSetSalary> GetSavS(string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                List<ModelSetSalary> adminDetails = new List<ModelSetSalary>();
                SqlCommand comd = new SqlCommand("uspSavSal", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Type", "SS");
                SqlDataReader reader = comd.ExecuteReader();
                while (reader.Read())
                {
                    ModelSetSalary detail = new ModelSetSalary();
                    detail.Empid = reader["Empid"].ToString();
                    detail.Sal = reader["Salary"].ToString();
                    detail.Saldate = reader["SalDate"].ToString();

                    adminDetails.Add(detail);
                }
                con.Close();
                return adminDetails.ToArray();
            }
        }

        //POST
        public string SaveSalary(ModelSetSalary ss, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("uspSavSal", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters.AddWithValue("@empid", ss.Empid.ToString());
                command.Parameters.AddWithValue("@sal", ss.Sal.ToString());
                command.Parameters.AddWithValue("@saldate", ss.Saldate.ToString());
                command.Parameters.AddWithValue("@Type", "SVS");
                command.ExecuteNonQuery();
                string result = "Saved !!!";
                //string result = command.Parameters["@Returnmessage"].Value.ToString();
                connection.Close();
                return result;
            }
        }
    }
}
