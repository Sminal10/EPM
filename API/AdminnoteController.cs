using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;

namespace EPM.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminnoteController : ControllerBase
    {
        DB.AdminNotes data = new DB.AdminNotes();
        private readonly IOptions<ModelConnectionString> appsetting;

        public AdminnoteController(IOptions<ModelConnectionString> option)
        {
            appsetting = option;
        }

        [HttpGet]
        [ActionName("GetAllNotes")]
        //GET: api/Adminnote/GetAllNotes
        public IEnumerable<ModelAdminNotes> GetAllAdminNotes()
        {
            return data.GetAllAdminNotes(appsetting.Value.DefaultConnection);
        }

        [HttpGet]
        [ActionName("GetSpecificNotes")]
        //GET: api/Adminnote/GetSpecificNotes?username=adityap
        public IEnumerable<ModelAdminNotes> GetSpfNotes(string username)
        {
            return data.GetSpfNotes(username, appsetting.Value.DefaultConnection);
        }

        [HttpPost]
        [ActionName("SaveNotes")]
        //POST: api/Adminnote/SaveNotes
        public string AdminNote(ModelAdminNotes notes)
        {
            return data.AdminNote(notes, appsetting.Value.DefaultConnection);
        }
    }
}
