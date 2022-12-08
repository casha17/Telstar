using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Telstar.DTOs;

namespace Telstar.Controllers
{
    [Route("api/edges")]
    [ApiController]
    public class MockController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetMockData()
        {

            List<EdgeResponseDTO> mockData = new List<EdgeResponseDTO>
        {
            new EdgeResponseDTO
            {
                City1 = "tunis",
                City2 = "tripoli",
                CostInUSD = 9,
                TimeInHours = 12
            }
        };
            return Ok(mockData);
        }
    }
}
