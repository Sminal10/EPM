using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;


namespace EPM.DB
{
    public class BDUploadDoc
    {
        public IEnumerable<ModelUploadDoc> GetUploadedDoc(string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                List<ModelUploadDoc> docs = new List<ModelUploadDoc>();
                SqlCommand command = new SqlCommand("uspUploadDocSD", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = 0;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "S";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ModelUploadDoc doc = new ModelUploadDoc();
                    doc.Id = reader["ID"].ToString();
                    doc.Imagepath = reader["ImagePath"].ToString();
                    doc.ADC = reader["AdhaarCardNum"].ToString();
                    doc.PAN = reader["PanCardNum"].ToString();
                    doc.BACC = reader["BnkAccNo"].ToString();
                    doc.BIFC = reader["BnkIFSC"].ToString();
                    doc.BBR = reader["BnkBranch"].ToString();
                    doc.Empid = reader["EmpID"].ToString();
                    docs.Add(doc);
                }
                con.Close();
                return docs.ToArray();
            } 
        }

        //POST
        public string UploadDoc(ModelUploadDoc doc, string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                /*ImgLib.ImageLibrary library = new ImgLib.ImageLibrary();
                var filename = "";
                var base64String = doc.Imagepath.ToString();
                filename = Guid.NewGuid().ToString();
                //Saving
                var Imgpath = library.SaveBase64StringInFolder(base64String, filename, "Image");*/

                con.Open();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand command = new SqlCommand("uspUploadDocAE", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters.AddWithValue("@Imagepath", doc.Imagepath);
                command.Parameters.AddWithValue("@Adhaarcardnum", doc.ADC.ToString());
                command.Parameters.AddWithValue("@Pancardnum", doc.PAN.ToString());
                command.Parameters.AddWithValue("@BnkAccno", doc.BACC.ToString());
                command.Parameters.AddWithValue("@BnkIFSC", doc.BIFC.ToString());
                command.Parameters.AddWithValue("@BnkBranch", doc.BBR.ToString());
                command.Parameters.AddWithValue("@Empid", doc.Empid.ToString());
                command.Parameters.AddWithValue("@Type","UP");
                command.ExecuteNonQuery();
                string result = "Updated";
                con.Close();
                return result;
            }
        }
    }
}
