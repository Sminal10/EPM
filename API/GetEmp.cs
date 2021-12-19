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
    public class GetEmp : ControllerBase
    {
        DB.DBGetmp data = new DB.DBGetmp();
        private readonly IOptions<ModelConnectionString> appsetting;

        public GetEmp(IOptions<ModelConnectionString> option)
        {
            appsetting = option;
        }

        // GET: api/GetEmp/GetAllEmp
        [HttpGet]
        [ActionName("GetAllEmp")]
        public IEnumerable<ModelEmpDetails> GetallEmp()
        {
            return data.GetallEmp(appsetting.Value.DefaultConnection);
        }

        // GET api/GetEmp/GetSingleEmp?username=rishi@gmail.com
        [HttpGet]
        [ActionName("GetSingleEmp")]
        public IEnumerable<ModelEmpDetails> GetSingleEmp(string username)
        {
            return data.GetSingleEmp(username,appsetting.Value.DefaultConnection);
        }

        // POST api/<GetEmp>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetEmp>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetEmp>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
