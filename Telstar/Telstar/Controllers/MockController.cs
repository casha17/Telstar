using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Telstar.DTOs;
using Telstar.Models;
using Telstar.service;
using TelstarLogistics.service;

namespace Telstar.Controllers
{
    [Route("api/edges")]
    [ApiController]
    public class MockController : ControllerBase
    {

        IshipmentService shipmentService;
        IGraphingService graphingService;

        public MockController(IshipmentService shipmentService, IGraphingService graphingService) {
            this.shipmentService = shipmentService;
            this.graphingService = graphingService;
        }

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


        [HttpGet]
        [Route("quickest")]
        public ActionResult getQuickestCheapest()
        {
            Shipment shipment = new()
            {
                weightInKg = "1",
                lengthInCm = "1",
                widthInCm = "1",
                heightInCm = "1",
                timestamp = DateTime.Now,
                type = new(){ name = Models.ShipmentType.REGULAR_TYPE }
            };
            String from = "tripoli";
            String to = "tunis";
            var quickestPath = this.graphingService.getQuickestPath(shipment, from, to);
            return Ok(quickestPath);
        }
    }
}
