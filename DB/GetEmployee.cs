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

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-39COJ7F\\SQLEXPRESS;Initial Catalog=EPM;Integrated Security=True");
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
                    modelGetEmp.Bdate = reader["BDate"].ToString();
                    modelGetEmp.Gender = reader["Gender"].ToString();
                    modelGetEmp.MaritalStatus = reader["MarritalStatus"].ToString();
                    modelGetEmp.Mobilenum = reader["MobileNmber"].ToString();
                    modelGetEmp.Altnum = reader["AlternateNmber"].ToString();
                    modelGetEmp.Address = reader["Address"].ToString();
                    modelGetEmp.State = reader["State"].ToString();
                    modelGetEmp.City = reader["City"].ToString();
                    modelGetEmp.Pincode = reader["Pincode"].ToString();
                    modelGetEmp.Salary = reader["Salary"].ToString();
                    modelGetEmp.Startdate = reader["StartDate"].ToString();
                    modelGetEmp.Qualification = reader["Qualifications"].ToString();
                    emps.Add(modelGetEmp);
                }
                con.Close();
                return emps.ToArray();
            }
        }

        // For Post
        public string Post(ModelAddNewEmp addNewEmp, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("uspMEmployeeAE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@Fname", addNewEmp.Fname.ToString());
                command.Parameters.AddWithValue("@Mname",addNewEmp.Mname.ToString());
                command.Parameters.AddWithValue("@Lname",addNewEmp.Lname.ToString());
                command.Parameters.AddWithValue("@Bdate",addNewEmp.Bdate.ToString());
                command.Parameters.AddWithValue("@Gender",addNewEmp.Gender.ToString());
                command.Parameters.AddWithValue("@Marritalstatus",addNewEmp.MaritalStatus.ToString());
                command.Parameters.AddWithValue("@Mobilenumber",addNewEmp.Mobilenum.ToString());
                command.Parameters.AddWithValue("@Alternatenumber",addNewEmp.Altnum.ToString());
                command.Parameters.AddWithValue("@Address",addNewEmp.Address.ToString());
                command.Parameters.AddWithValue("@State",addNewEmp.State.ToString());
                command.Parameters.AddWithValue("@City",addNewEmp.City.ToString());
                command.Parameters.AddWithValue("@Pincode",addNewEmp.Pincode.ToString());
                command.Parameters.AddWithValue("@Salary",addNewEmp.Salary.ToString());
                command.Parameters.AddWithValue("@Startdate",addNewEmp.Startdate.ToString());
                command.Parameters.AddWithValue("@Qualification",addNewEmp.Qualification.ToString());
                command.Parameters.AddWithValue("@Emailid",addNewEmp.Emailid.ToString());
                command.Parameters.AddWithValue("@Emppassword", addNewEmp.Password.ToString());
                command.Parameters.AddWithValue("@Type","A");
                command.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();

                string result = command.Parameters["@Returnmessage"].Value.ToString();
                connection.Close();
                return result;
            }
        }

        public IEnumerable<ModelGetSingleEmp> GetSingleEmp(int id)
        {
                if(con.State == ConnectionState.Closed) {con.Open();}
                
                List<ModelGetSingleEmp> oneemp = new List<ModelGetSingleEmp>();
                SqlCommand command = new SqlCommand("uspMEmployeeSD", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "GI";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelGetSingleEmp singleEmp = new ModelGetSingleEmp();
                    singleEmp.EmpId = reader["EmpId"].ToString();
                    singleEmp.Fname = reader["FName"].ToString();
                    singleEmp.Mname = reader["MName"].ToString();
                    singleEmp.Lname = reader["LName"].ToString();
                    singleEmp.Bdate = reader["BDate"].ToString();
                    singleEmp.Gender = reader["Gender"].ToString();
                    singleEmp.Mobilenum = reader["MobileNmber"].ToString();
                    oneemp.Add(singleEmp);
                }
                con.Close();
                return oneemp.ToArray();
            
        }
    }
}
