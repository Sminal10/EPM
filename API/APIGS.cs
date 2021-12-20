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

        // GET: api/APIGS/GetSvdS
        [HttpGet]
        [ActionName("GetSvdS")]
        public IEnumerable<ModelSetSalary> GetSavS()
        {
            return data.GetSavS(appsetting.Value.DefaultConnection);
        }

        // GET api/APIGS/GetSInf?username=EPMAD01
        [HttpGet]
        [ActionName("GetSInf")]
        public IEnumerable<ModelGS> GetGetInf(string username)
        {
            return data.GetGetInf(username, appsetting.Value.DefaultConnection);
        }

        // POST api/APIGS/SaveSal
        [HttpPost]
        [ActionName("SaveSal")]
        public string SaveSalary(ModelSetSalary ss)
        {
            return data.SaveSalary(ss, appsetting.Value.DefaultConnection);
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
