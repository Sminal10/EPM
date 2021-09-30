using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPM.DB
{
    public class GetEmployee
    {
        public IEnumerable<ModelGetEmp> GetEmp(string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                List<ModelGetEmp> emps = new List<ModelGetEmp>();
                SqlCommand command = new SqlCommand("uspMEmployeeSD", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = 0;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "S";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelGetEmp modelGetEmp = new ModelGetEmp();
                    modelGetEmp.Id = reader["Id"].ToString();
                    modelGetEmp.Empid = reader["EmpId"].ToString();
                    modelGetEmp.Fname = reader["FName"].ToString();
                    modelGetEmp.Mname = reader["MName"].ToString();
                    modelGetEmp.Lname = reader["LName"].ToString();
                    emps.Add(modelGetEmp);
                }
                con.Close();
                return emps.ToArray();
            }
        }
    }
}
