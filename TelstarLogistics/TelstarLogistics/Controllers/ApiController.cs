using Microsoft.AspNetCore.Mvc;
using TelstarLogistics.Data;
using TelstarLogistics.DTOs;

namespace TelstarLogistics.Controllers;

public class ApiController : ControllerBase
{

    [Route("api/edges")]
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