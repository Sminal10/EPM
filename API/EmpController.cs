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
    public class EmpController : ControllerBase
    {
        DB.GetEmployee data = new DB.GetEmployee();

        private readonly IOptions<ModelConnectionString> appsetting;
        public EmpController(IOptions<ModelConnectionString> app)
        {
            appsetting = app;
        }

        // GET: api/Emp
        [HttpGet]
        [ActionName("GetAllEmp")]
        public IEnumerable<ModelGetEmp> GetEmp()
        {
            return data.GetEmp(appsetting.Value.DefaultConnection);
        }

        // GET api/<EmpController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
