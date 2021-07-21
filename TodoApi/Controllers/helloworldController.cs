using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class helloworldController : ControllerBase
    {
        // GET: api/<helloworldController>
        [HttpGet]
        public IActionResult Get()
        {
            List< Dictionary<string, string>> data = new List<Dictionary<string, string>> (){
                new Dictionary<string, string>() { { "name", "CardActive" }, { "type", "switch" }, { "value", "on" } },
                new Dictionary<string, string>() { { "name", "ChangeUsernameAndPassword" }, { "type", "multiple" }, { "value", "Permission Denied" } }
            };
            //var data = new string[] { "value11", "value2" };
            return new JsonResult(data);
        }

        // GET api/<helloworldController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<helloworldController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<helloworldController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<helloworldController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
