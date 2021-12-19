using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPM.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class APIAdminDetails : ControllerBase
    {
        DB.DBAdminLogin data= new DB.DBAdminLogin();
        private readonly IOptions<ModelConnectionString> appsetting;

        public APIAdminDetails(IOptions<ModelConnectionString> option)
        {
            appsetting = option;
        }

        [HttpGet]
        [ActionName("GetAllAdmin")]
        // GET: api/APIAdminDetails/GetAllAdmin
        public IEnumerable<ModelAdminDetail> GetallAdmins()
        {
            return data.GetallAdmins(appsetting.Value.DefaultConnection);
        }

        [HttpGet]
        [ActionName("GetSingleAdmin")]
        // GET api/APIAdminDetails/GetSingleAdmin?username=adityap
        public IEnumerable<ModelAdminDetail> GetSingleAdmin(string username)
        {
            return data.GetSingleAdmin(username, appsetting.Value.DefaultConnection);
        }

        // POST api/<APIAdminDetails>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIAdminDetails>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIAdminDetails>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
