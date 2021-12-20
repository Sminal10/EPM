using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.IO;
using System.Globalization;
using System.Text;


namespace EPM.DB
{
    public class GetEmployee
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-39COJ7F\\SQLEXPRESS;Initial Catalog=EPM;Integrated Security=True");

        //For GET
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

        public IEnumerable<ModelAddNewEmp> GetEmpUpdt(int Id)
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            List<ModelAddNewEmp> test = new List<ModelAddNewEmp>();
            SqlCommand cmd = new SqlCommand("uspMEmployeeSD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "E";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ModelAddNewEmp lg = new ModelAddNewEmp();

                lg.Id = dr["Id"].ToString();
                lg.Empid =dr["EmpId"].ToString();
                lg.Fname = dr["FName"].ToString();
                lg.Mname = dr["MName"].ToString();
                lg.Lname = dr["LName"].ToString();
                lg.Bdate = dr["BDate"].ToString();
                lg.Gender = dr["Gender"].ToString();
                lg.MaritalStatus = dr["MarritalStatus"].ToString();
                lg.Mobilenum = dr["MobileNmber"].ToString();
                lg.Altnum = dr["AlternateNmber"].ToString();
                lg.Address = dr["Address"].ToString();
                lg.State = dr["State"].ToString();
                lg.City = dr["City"].ToString();
                lg.Pincode = dr["Pincode"].ToString();
                lg.Salary = dr["Salary"].ToString();
                lg.Startdate = dr["StartDate"].ToString();
                lg.Qualification = dr["Qualifications"].ToString();
                lg.Emailid = dr["Emailid"].ToString();
                lg.Password = dr["EmpPassword"].ToString();

                test.Add(lg);
            }
            con.Close();

            return test.ToArray();
        }


        // For Post
        //public string Post(ModelAddNewEmp addNewEmp, string ConnectionString)
        //{
        //    //using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    //{
        //        if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }

        //    SqlCommand command = new SqlCommand("uspMEmployeeAE", con);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@Id", 0);
        //        command.Parameters.AddWithValue("@Fname", addNewEmp.Fname.ToString());
        //        command.Parameters.AddWithValue("@Mname",addNewEmp.Mname.ToString());
        //        command.Parameters.AddWithValue("@Lname",addNewEmp.Lname.ToString());
        //        command.Parameters.AddWithValue("@Bdate",addNewEmp.Bdate.ToString());
        //        command.Parameters.AddWithValue("@Gender",addNewEmp.Gender.ToString());
        //        command.Parameters.AddWithValue("@Marritalstatus",addNewEmp.MaritalStatus.ToString());
        //        command.Parameters.AddWithValue("@Mobilenumber",addNewEmp.Mobilenum.ToString());
        //        command.Parameters.AddWithValue("@Alternatenumber",addNewEmp.Altnum.ToString());
        //        command.Parameters.AddWithValue("@Address",addNewEmp.Address.ToString());
        //        command.Parameters.AddWithValue("@State",addNewEmp.State.ToString());
        //        command.Parameters.AddWithValue("@City",addNewEmp.City.ToString());
        //        command.Parameters.AddWithValue("@Pincode",addNewEmp.Pincode.ToString());
        //        command.Parameters.AddWithValue("@Salary",addNewEmp.Salary.ToString());
        //        command.Parameters.AddWithValue("@Startdate",addNewEmp.Startdate.ToString());
        //        command.Parameters.AddWithValue("@Qualification",addNewEmp.Qualification.ToString());
        //        command.Parameters.AddWithValue("@Emailid",addNewEmp.Emailid.ToString());
        //        command.Parameters.AddWithValue("@Emppassword", addNewEmp.Password.ToString());
        //        command.Parameters.AddWithValue("@Type","A");
        //        
        //        command.ExecuteNonQuery();

        //        string result = command.Parameters["@Returnmessage"].Value.ToString();
        //        con.Close();
        //        return result;
        //    //}
        //}

        public string Post(ModelAddNewEmp stud)
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("uspMEmployeeAE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar).Value = stud.Fname.ToString();
            cmd.Parameters.Add("@Mname", SqlDbType.VarChar).Value = stud.Mname.ToString();
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar).Value = stud.Lname.ToString();
            cmd.Parameters.Add("@Bdate", SqlDbType.VarChar).Value = stud.Bdate.ToString();
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = stud.Gender.ToString();
            cmd.Parameters.Add("@Marritalstatus", SqlDbType.VarChar).Value = stud.MaritalStatus.ToString();
            cmd.Parameters.Add("@Mobilenumber", SqlDbType.VarChar).Value = stud.Mobilenum.ToString();
            cmd.Parameters.Add("@Alternatenumber", SqlDbType.VarChar).Value = stud.Altnum.ToString();
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = stud.Address.ToString();
            cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = stud.State.ToString();
            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = stud.City.ToString();
            cmd.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = stud.Pincode.ToString();
            cmd.Parameters.Add("@Salary", SqlDbType.VarChar).Value = stud.Salary.ToString();
            cmd.Parameters.Add("@Startdate", SqlDbType.VarChar).Value = stud.Startdate.ToString();
            cmd.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = stud.Qualification.ToString();
            cmd.Parameters.Add("@Emailid", SqlDbType.VarChar).Value = stud.Emailid.ToString();
            cmd.Parameters.Add("@Emppassword", SqlDbType.VarChar).Value = stud.Password.ToString();
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "A";
            cmd.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@Returnmessage"].Value.ToString();
            con.Close();
            return result;

        }

        //public IEnumerable<ModelGetSingleEmp> GetSingleEmp(int id)
        //{
        //        if(con.State == ConnectionState.Closed) {con.Open();}
                
        //        List<ModelGetSingleEmp> oneemp = new List<ModelGetSingleEmp>();
        //        SqlCommand command = new SqlCommand("uspMEmployeeSD", con);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add("@Type", SqlDbType.Char).Value = "GI";
        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            ModelGetSingleEmp singleEmp = new ModelGetSingleEmp();
        //            singleEmp.EmpId = reader["EmpId"].ToString();
        //            singleEmp.Fname = reader["FName"].ToString();
        //            singleEmp.Mname = reader["MName"].ToString();
        //            singleEmp.Lname = reader["LName"].ToString();
        //            singleEmp.Bdate = reader["BDate"].ToString();
        //            singleEmp.Gender = reader["Gender"].ToString();
        //            singleEmp.Mobilenum = reader["MobileNmber"].ToString();
        //            oneemp.Add(singleEmp);
        //        }
        //        con.Close();
        //        return oneemp.ToArray();
            
        //}


        public string Put(int id, ModelAddNewEmp stud)
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("uspMEmployeeAE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar).Value = stud.Fname.ToString();
            cmd.Parameters.Add("@Mname", SqlDbType.VarChar).Value = stud.Mname.ToString();
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar).Value = stud.Lname.ToString();
            cmd.Parameters.Add("@Bdate", SqlDbType.VarChar).Value = stud.Bdate.ToString();
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = stud.Gender.ToString();
            cmd.Parameters.Add("@Marritalstatus", SqlDbType.VarChar).Value = stud.MaritalStatus.ToString();
            cmd.Parameters.Add("@Mobilenumber", SqlDbType.VarChar).Value = stud.Mobilenum.ToString();
            cmd.Parameters.Add("@Alternatenumber", SqlDbType.VarChar).Value = stud.Altnum.ToString();
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = stud.Address.ToString();
            cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = stud.State.ToString();
            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = stud.City.ToString();
            cmd.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = stud.Pincode.ToString();
            cmd.Parameters.Add("@Salary", SqlDbType.VarChar).Value = stud.Salary.ToString();
            cmd.Parameters.Add("@Startdate", SqlDbType.VarChar).Value = stud.Startdate.ToString();
            cmd.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = stud.Qualification.ToString();
            cmd.Parameters.Add("@Emailid", SqlDbType.VarChar).Value = stud.Emailid.ToString();
            cmd.Parameters.Add("@Emppassword", SqlDbType.VarChar).Value = stud.Password.ToString();
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "U";
            cmd.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@Returnmessage"].Value.ToString();
            con.Close();

            return result;
        }


        public string Delete(int id)
        {
            List<ModelAddNewEmp> test = new List<ModelAddNewEmp>();
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("uspMEmployeeSD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            //cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = deletedby;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "D";
            cmd.Parameters.Add("@Returnmessage", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@Returnmessage"].Value.ToString();
            con.Close();
            return result;
        }



    }
}
