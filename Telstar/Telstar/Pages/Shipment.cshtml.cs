using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Telstar.Models;
using Telstar.service;
using TelstarLogistics.service;

namespace Telstar.Pages
{
    public class ShipmentModel : PageModel
    {


        [BindProperty]
        public string toDestination { get; set; }

        [BindProperty]
        public string fromDestination { get; set; }

        // Cities
        private readonly IshipmentService _shipmentService;

        public List<String> destinations { get; set; }

        private readonly IGraphingService graphingService1;

        public ShipmentModel(IshipmentService ishipmentService, IGraphingService graphingService)
        {
            var listOfDestinations = ishipmentService.GetDestination();
            destinations = new List<String>();
            listOfDestinations.ForEach(elem => destinations.Add(elem.City));
            graphingService1 = graphingService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string toDestination, string fromDestination, DateTime tripStart, string typeRadios)
        {
            var shipment = new Shipment
            {
                Id = Guid.NewGuid(),
                timestamp = tripStart,
                from = fromDestination,
                to = toDestination,
                type = new ShipmentType
                {
                    name = typeRadios,
                    id = Guid.NewGuid(),
                    priceModifier = 0,
                    shipments = null,
                },

            };

            var quickest =  graphingService1.getQuickestPath(shipment, toDestination, fromDestination);
            var cheapest =  graphingService1.getCheapestPath(shipment, toDestination, fromDestination);

            var obj = new AlgorithmResult
            {
                Cheapest = quickest.Distance / 100.0,
                Fastest = cheapest.Distance / 100.0 ,
                shipment= shipment,
            };

            TempData["path"] = JsonSerializer.Serialize(obj);
            return RedirectToPage("/DimensionPage");

        }
    }
}
