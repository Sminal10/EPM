﻿using System;
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
    public class DBAnnouncement
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-39COJ7F\\SQLEXPRESS;Initial Catalog=EPM;Integrated Security=True");

        public string PostNote(ModelAnnouncement stud)
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Proc_NoteAE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Event", SqlDbType.VarChar).Value = stud.Event;
            cmd.Parameters.Add("@EventStartDate", SqlDbType.VarChar).Value = stud.EventStartDate.ToString();
            cmd.Parameters.Add("@EventEndDate", SqlDbType.VarChar).Value = stud.EventEndDate.ToString();
            cmd.Parameters.Add("@EventDesc", SqlDbType.VarChar).Value = stud.EventDesc.ToString();
           
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "E";
            cmd.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@Returnmessage"].Value.ToString();
            con.Close();
            return result;

        }


        public string PostAward(ModelAnnouncement stud)
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("Proc_AwardAE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@AwardeeName", SqlDbType.VarChar).Value = stud.AwardeeName.ToString();
            cmd.Parameters.Add("@Award", SqlDbType.VarChar).Value = stud.Award.ToString();
            cmd.Parameters.Add("@Organization", SqlDbType.VarChar).Value = stud.Organization.ToString();
            cmd.Parameters.Add("@AwardedDate", SqlDbType.VarChar).Value = stud.AwardedDate.ToString();
            cmd.Parameters.Add("@Attachment", SqlDbType.VarChar).Value = stud.Attachment.ToString();
            cmd.Parameters.Add("@AwardDesc", SqlDbType.VarChar).Value = stud.AwardDesc.ToString();
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "A";
            cmd.Parameters.Add("@Returnmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@Returnmessage"].Value.ToString();
            con.Close();
            return result;

        }

        public IEnumerable<ModelShowAnnouncement> GetAnnouncement(int Id)
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            List<ModelShowAnnouncement> test = new List<ModelShowAnnouncement>();
            SqlCommand cmd = new SqlCommand("Proc_ShowAnnouncement", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "DisEvt";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ModelShowAnnouncement lg = new ModelShowAnnouncement();

                lg.Id = dr["Id"].ToString();
                lg.EventName = dr["Event"].ToString();
                lg.StartDate = dr["EventStartDate"].ToString();
                lg.EndDate = dr["EventEndDate"].ToString();
                lg.Desc = dr["EventDesc"].ToString();             

                test.Add(lg);
            }
            con.Close();

            return test.ToArray();
        }

    }
}
