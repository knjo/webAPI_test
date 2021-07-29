using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using TodoApi.Models;
using Microsoft.Extensions.Configuration;
using System.Data.Entity;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{

    [Route("/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;

        public TransactionController(IConfiguration configuration )
        {
            _configuration = configuration;
        } 
        private void modifyData(Feature _feature, Dictionary<string, object> changeData)
        {
            _feature.State = Convert.ToBoolean(changeData["state"].ToString());
            _feature.Starttime = Convert.ToString(changeData["starttime"]);
            _feature.Endtime = Convert.ToString(changeData["endtime"]);
            _feature.Status = Convert.ToString(changeData["status"]);
            _feature.Biometrics = Convert.ToBoolean(changeData["biometrics"].ToString());
            _feature.Verificationcode = Convert.ToBoolean(changeData["verificationcode"].ToString());
            _feature.Single = Convert.ToInt32(changeData["single"].ToString());
            _feature.Day = Convert.ToInt32(changeData["day"].ToString());
            _feature.Month = Convert.ToInt32(changeData["month"].ToString());
        }
        // GET: api/<helloworldController>

        [HttpGet]
        [Route("api/transaction")]
        public IActionResult Get()
        {
            Console.WriteLine("GET request");

             Feature fuction ;
              using (var transDB = new backgroundContext())
              {
                  var data = transDB.Features.Where(b => b.Name == "NT_Transaction").First();
                  fuction = data;
                  Console.WriteLine(data.Name);
              }
              return new JsonResult(fuction);
 
        }

        [HttpPost]
        [Route("api/transaction")]
        public IActionResult Post(Dictionary<string, object> changeData)
        {       
            Console.WriteLine("POST request");
           
            try {
                using (var transDB = new backgroundContext())
                {
                    var data =  transDB.Features.Where(b => b.Name =="NT_Transaction").First();
                    Console.WriteLine(data.Starttime);
                    Console.WriteLine(changeData["starttime"]);
        
                    modifyData(data, changeData);
                    Console.WriteLine(data.Starttime);
                    transDB.SaveChanges();
                }
                return new JsonResult("success");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);    
                return new JsonResult("failed"); }
            
        }    
    }
}
