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
    public class APIGetSS : ControllerBase
    {
        DB.DBGenerateSalary data = new DB.DBGenerateSalary();
        private readonly IOptions<ModelConnectionString> appsetting;

        public APIGetSS(IOptions<ModelConnectionString> option)
        {
            appsetting = option;
        }

        // GET: api/<APIGetSS>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/APIGetSS/ShowSS?username=rishi@gmail.com
        [HttpGet]
        [ActionName("ShowSS")]
        public IEnumerable<ModelShowSS> GetEmpSS(string username)
        {
            return data.GetEmpSS(username,appsetting.Value.DefaultConnection);
        }

        // POST api/<APIGetSS>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIGetSS>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIGetSS>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
