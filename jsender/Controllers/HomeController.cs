using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsender.API.Models;
using jsender.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jsender.API.Controllers
{
  
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: /<controller>/
        [HttpGet]
        public ActionResult GetUrls()
        {
            var url = new ApiUrl()
            {
                Url = "messages_url",
                Value = $"api/v1/transactions"
            };

            return Ok(url);
        }
    }
}
