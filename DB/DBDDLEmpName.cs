using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPM.DB
{
    public class DBDDLEmpName
    {
        //GET: ALL EMP NAMES
        public IEnumerable<ModelDDLEmpName> GetAllEmpName(string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                List<ModelDDLEmpName> empNames = new List<ModelDDLEmpName>();
                SqlCommand command = new SqlCommand("uspDDLEmpNameSD", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = 0;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "EN";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ModelDDLEmpName name = new ModelDDLEmpName();
                    name.Empid = reader["EmpId"].ToString();
                    name.Fname = reader["FName"].ToString();
                    name.Mname = reader["MName"].ToString();
                    name.Lname = reader["LName"].ToString();
                    empNames.Add(name);
                }
                con.Close();
                return empNames.ToArray();
            }
        }
    }
}
