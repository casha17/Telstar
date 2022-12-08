using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Telstar.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class EdgesController : ControllerBase
    {
        private string DbConnection { get; set; }

            [HttpGet]
            
            public IActionResult Get(string from, string to)
            {
                   return Ok("working");
            }

            
        

    }
}
