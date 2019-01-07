using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Communication;
using Microsoft.AspNetCore.Mvc;

namespace testAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpPost]
        [Route("readresponse")]
        public string Readresponse()
        {
            
            string url4 = "https://localhost:44334/api/Values/writeResponse";
            string re4 = HttpService.Post(url4, "<xml><name>kikiki</name></xml>");
            Stream stream = HttpContext.Response.Body;
            StreamReader sr = new StreamReader(stream);
            string result = sr.ReadToEnd();
            sr.Close();
            return result;
        }
    }
}
