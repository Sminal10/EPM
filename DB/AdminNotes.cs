using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPM.DB
{
    public class AdminNotes
    {

        //GET: all notes
        public IEnumerable<ModelAdminNotes> GetAllAdminNotes(string ConnectionString)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                List<ModelAdminNotes> adminNotes = new List<ModelAdminNotes>();
                SqlCommand command = new SqlCommand("uspMAdminNotesSD", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = 0;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "SN";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ModelAdminNotes adnotes = new ModelAdminNotes();
                    adnotes.Id = reader["Id"].ToString();
                    adnotes.Notes = reader["Notes"].ToString();
                    adnotes.AdminUsername = reader["AdminUsername"].ToString();
                    adminNotes.Add(adnotes);
                }
                connection.Close();
                return adminNotes.ToArray();
            }
        }


        //POST
        public string AdminNote(ModelAdminNotes adminNotes, string ConnectionString)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("uspMAdminNotesAE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters.AddWithValue("@Notes", adminNotes.Notes.ToString());
                command.Parameters.AddWithValue("@AdminUsername", adminNotes.AdminUsername.ToString());
                command.Parameters.AddWithValue("@Type", "AN");
                command.ExecuteNonQuery();
                string result ="Noted !!!";
                //string result = command.Parameters["@Returnmessage"].Value.ToString();
                connection.Close();
                return result;
            }
        }

        //GET:  single user notes
        public IEnumerable<ModelAdminNotes> GetSpfNotes(string username, string ConnectionString)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                List<ModelAdminNotes> adminNotes = new List<ModelAdminNotes>();
                SqlCommand command = new SqlCommand("uspMAdminNotesSN", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Type", "SSN");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ModelAdminNotes notes = new ModelAdminNotes();
                    notes.Notes = reader["Notes"].ToString();
                    notes.AdminUsername = reader["AdminUsername"].ToString();
                    adminNotes.Add(notes);
                }
                connection.Close();
                return adminNotes.ToArray();
            }
        }
    }
}
