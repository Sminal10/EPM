using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using EPM.DB;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPM.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        DB.AdminDetails data = new DB.AdminDetails();

        private readonly IOptions<ConnectionString> appsettings;
        public AdminController(IOptions<ConnectionString> app)
        {
            appsettings = app;
        }


        // GET: api/Admin/GetDetails
        [HttpGet]
        [ActionName("GetDetails")]
        public IEnumerable<GetAdminDetails> GetAdminDetails()
        {
            return data.GetAdminDetails(appsettings.Value.DefaultConnection);
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
