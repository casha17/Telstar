using Microsoft.AspNetCore.Mvc;
using TelstarLogistics.Data;

namespace TelstarLogistics.Controllers;

public class ApiController : ControllerBase
{
    
    [Route("api/edges")]
    [HttpGet]
    public ActionResult GetMockData()
    {

        List<MockData> mockData = new List<MockData>
        {
            new MockData
            {
                CityFrom = "tunis",
                CityTo = "tripoli",
                CostInUSD = 9,
                TimeInHours = 12
            }
        };
        return Ok(mockData);
    }
}