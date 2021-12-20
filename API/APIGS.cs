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
    public class APIGS : ControllerBase
    {
        DB.DBGenerateSalary data = new DB.DBGenerateSalary();
        private readonly IOptions<ModelConnectionString> appsetting;

        public APIGS(IOptions<ModelConnectionString> option)
        {
            appsetting = option;
        }

        // GET: api/<APIGS>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/APIGS/GetSInf?username=EPMAD01
        [HttpGet]
        [ActionName("GetSInf")]
        public IEnumerable<ModelGS> GetGetInf(string username)
        {
            return data.GetGetInf(username, appsetting.Value.DefaultConnection);
        }

        // POST api/<APIGS>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIGS>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIGS>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
