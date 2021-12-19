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
    public class APIUploadDocController : ControllerBase
    {
        DB.BDUploadDoc data = new DB.BDUploadDoc();
        private readonly IOptions<ModelConnectionString> appsettings;

        public APIUploadDocController(IOptions<ModelConnectionString> options)
        {
            appsettings = options;
        }

        // GET: api/APIUploadDoc/GetUpldDoc
        [HttpGet]
        [ActionName("GetUpldDoc")]
        public IEnumerable<ModelUploadDoc> GetUploadedDoc()
        {
            return data.GetUploadedDoc(appsettings.Value.DefaultConnection);
        }

        // GET api/<APIUploadDocController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/APIUploadDoc/UploadData
        [HttpPost]
        [ActionName("UploadData")]
        public string Post(ModelUploadDoc uploadDoc)
        {
            return data.UploadDoc(uploadDoc, appsettings.Value.DefaultConnection);
        }

        // PUT api/<APIUploadDocController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIUploadDocController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
