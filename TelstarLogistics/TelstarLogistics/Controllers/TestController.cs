using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelstarLogistics.service;

namespace TelstarLogistics.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IshipmentService _shipmentService;
        public TestController(IshipmentService ishipmentService) { 
            _shipmentService= ishipmentService;
        }

        [HttpGet]
        public IActionResult GetDestinations() {
            var result = _shipmentService.GetDestination();
            return Ok(result);
        }
    }
}
