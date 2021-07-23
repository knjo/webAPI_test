using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{


    //[Route("api/[controller]")]
    [ApiController]
    public class helloworldController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public helloworldController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string toCommand(Dictionary<string, object> changeData)
        {
            string command = "UPDATE FEATURE SET ";
            int i = 0;
            foreach (KeyValuePair<string, object> item in changeData)
            {
                if (item.Key.ToString() == "name") { continue; }
                if (i > 0) { command += ","; }
                command += item.Key.ToString() + "='" + item.Value.ToString() + "' ";
                i++;
            }
            command += " WHERE name='NT_Transaction'";
            Console.WriteLine(command);

            return command;
        }
        // GET: api/<helloworldController>
        [HttpGet]
        [Route("api/helloworld")]
        public IActionResult Get()
        {
            Console.WriteLine("GET request");

                  List<Dictionary<string, object>> fuctions = new List<Dictionary<string, object>>();
        using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDatabase")))
            {
                var sql = "SELECT * FROM FEATURE";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                Dictionary<string, object> fuction = new Dictionary<string, object>() 
                {
                    { "name", reader["name"] }, 
                    { "state", reader["state"] },
                    { "starttime", reader["starttime"] },
                    { "endtime", reader["endtime"]},
                    { "status", reader["status"] },
                    { "biometrics", reader["biometrics"] },
                    { "verificationcode", reader["verificationcode"] },
                    { "single", reader["single"]},
                    { "day", reader["day"] },
                    { "month", reader["month"]},
                };

                 fuctions.Add(fuction);
                }
            }
            
            return new JsonResult(fuctions);
        }

        [HttpPost]
        [Route("api/helloworld")]
        public IActionResult Post(Dictionary<string, object> changeData)
        {       
            Console.WriteLine("POST request");
            var sql = toCommand(changeData);
            try {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDatabase")))
                {

                    connection.Open();
                    using SqlCommand command = new SqlCommand(sql, connection);
                    using SqlDataReader reader = command.ExecuteReader(); ;
                    Console.WriteLine(reader);
                }
                return new JsonResult("success");
            }
            catch { return new JsonResult("failed"); }
            
        }
        

        /*
        public IActionResult Post()
        {

            Console.WriteLine("get post");
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EmployeeDatabase")))
            {
                var sql = "UPDATE FEATURE SET biometrics='false', day='5555' WHERE name='NT_Transaction'";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader(); ;
                Console.WriteLine(reader);
            }
            return Ok();
        }*/
    }
}
