using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPM.DB
{
    public class DBGetmp
    {
        //GET All
        public IEnumerable<ModelEmpDetails> GetallEmp(string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                List<ModelEmpDetails> details = new List<ModelEmpDetails>();
                SqlCommand command = new SqlCommand("uspGetEmpS", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "GE";
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ModelEmpDetails model = new ModelEmpDetails();
                    model.FName = read["FName"].ToString();
                    model.MName = read["MName"].ToString();
                    model.LName = read["LName"].ToString();
                    model.Mnum = read["MobileNmber"].ToString();
                    model.Altnum = read["AlternateNmber"].ToString();
                    model.Add = read["Address"].ToString();
                    model.State = read["State"].ToString();
                    model.City = read["City"].ToString();
                    model.Pincode = read["Pincode"].ToString();
                    details.Add(model);
                }
                connection.Close();
                return details.ToArray();
            }
        }

        public IEnumerable<ModelEmpDetails> GetSingleEmp(string username, string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                List<ModelEmpDetails> adminDetails = new List<ModelEmpDetails>();
                SqlCommand comd = new SqlCommand("uspGetEmpS", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Username", username);
                comd.Parameters.AddWithValue("@Type", "GE");
                SqlDataReader read = comd.ExecuteReader();
                while (read.Read())
                {
                    ModelEmpDetails detail = new ModelEmpDetails();
                    detail.FName = read["FName"].ToString();
                    detail.MName = read["MName"].ToString();
                    detail.LName = read["LName"].ToString();
                    detail.Mnum = read["MobileNmber"].ToString();
                    detail.Altnum = read["AlternateNmber"].ToString();
                    detail.Add = read["Address"].ToString();
                    detail.State = read["State"].ToString();
                    detail.City = read["City"].ToString();
                    detail.Pincode = read["Pincode"].ToString(); ;
                    adminDetails.Add(detail);
                }
                con.Close();
                return adminDetails.ToArray();
            }
        }
    }
}
