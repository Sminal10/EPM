using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using EPM.DB;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace EPM.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AnnouncementAPIController : ControllerBase
    {
        DB.DBAnnouncement datatest = new DB.DBAnnouncement();

        [HttpPost]
        [ActionName("SaveNote")]
        public string PostNote(ModelAnnouncement stud)
        {
            var postMethod = datatest.PostNote(stud);
            return postMethod;
        }

        [HttpPost]
        [ActionName("SaveAward")]
        public string PostAward(ModelAnnouncement stud)
        {
            var postMethod = datatest.PostAward(stud);
            return postMethod;
        }

        [HttpGet]
        [ActionName("GetAnnounce")]
        // GET: api/AnnouncementAPI/GetAnnounce
        public IEnumerable<ModelShowAnnouncement> GetAnnouncement(int Id)
        {
            return datatest.GetAnnouncement(Id);
        }


    }
}
