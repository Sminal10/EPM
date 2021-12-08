using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPM.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class APIDDLEmpNameController : ControllerBase
    {
        DB.DBDDLEmpName data= new DB.DBDDLEmpName();
        private readonly IOptions<ModelConnectionString> appsetting;

        public APIDDLEmpNameController(IOptions<ModelConnectionString> option)
        {
            appsetting = option;
        }
        // GET: api/APIDDLEmpName/GetEmpNames
        [HttpGet]
        [ActionName("GetEmpNames")]
        public IEnumerable<ModelDDLEmpName> GetAllEmpName()
        {
            return data.GetAllEmpName(appsetting.Value.DefaultConnection);
        }

        // GET api/<APIDDLEmpNameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIDDLEmpNameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIDDLEmpNameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIDDLEmpNameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
