using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telstar.Data;
using Telstar.DTOs;
using Telstar.Models;
using Telstar.service;
using Telstar.service;
using Type = System.Type;

namespace Telstar.Controllers
{
    [Route("api/edges")]
    [ApiController]
    public class MockController : ControllerBase
    {

        private ApplicationDbContext _context;
        private IshipmentService _shipmentService;
        private readonly IGraphingService graphingService;

        public MockController(ApplicationDbContext context, IshipmentService ishipmentService, IGraphingService graphingService)
        {
            _context = context;
            _shipmentService = ishipmentService;
            graphingService = graphingService;
        }

        [HttpGet]
        //Create a http get that takes two parameters in the request body
        public ActionResult SendEdges(string companyName, float weight, float length, float width, float height,
            string type,
            DateTime timestamp, bool recommended)
        {

            //Create a new shipment object 
            Shipment shipment = new Shipment()
            {
                weightInKg = weight,
                lengthInCm = length,
                widthInCm = width,
                heightInCm = height,
                timestamp = timestamp,
                type = new()
                {
                    name = type
                }
            };

            //Create a company object
            var company = new Company(companyName, null);

            //Retrieve all edges from database
            var edges = _context.edges.ToList();


            //Apply modifcation filter to edges depending on request body parameters
            //CalculateAdjustedPrice
            foreach (var edge in edges)
            {
                edge.Cost = _shipmentService.calculateAdjustedPrice(shipment, company, edge.Cost);
            }


            bool isEITC = company.name.ToUpper() == Company.EITC.name.ToUpper();
            bool isOA = company.name.ToUpper() == Company.OA.name.ToUpper();
            bool allowedForEITC = shipment.weightInKg <= 100;
            bool allowedForOA = shipment.weightInKg <= 20 && shipment.lengthInCm <= 200 &&
                                shipment.type.name.ToLower() != Telstar.Models.ShipmentType.ANIMAL_TYPE.ToLower() && shipment.type.name.ToLower() != Telstar.Models.ShipmentType.WEAPONS_TYPE;

            //Create list of edges to send 
            var edgesToSend = new List<Edge>();

            foreach (var edge in edges)
            {
                if (isEITC && allowedForEITC)
                {
                    edgesToSend.Add(edge);
                }

                if (isOA && allowedForOA)
                {
                    edgesToSend.Add(edge);
                }
            }

            var integrationViewModels = new List<IntegrationViewModel>();
            foreach (var edge in edgesToSend)
            {
                integrationViewModels.Add(new IntegrationViewModel
                {
                    city1 = edge.From,
                    city2 = edge.To,
                    costInUSD = edge.Cost,
                    timeInHours = edge.TimeHours
                });
            }

            return Ok(integrationViewModels);
        }



        [HttpGet]
        [Route("/mock")]
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
                weightInKg = 1,
                lengthInCm = 1,
                widthInCm = 1,
                heightInCm = 1,
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
