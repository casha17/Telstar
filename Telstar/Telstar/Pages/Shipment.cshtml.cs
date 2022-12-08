using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            graphingService = graphingService1;
        }

        public void OnGet()
        {
        }

        public void OnPost(string toDestination, string fromDestination, DateTime tripStart, string typeRadios)
        {
            var shipment = new Shipment
            {
                Id = Guid.NewGuid(),
                timestamp = tripStart,
                type = new ShipmentType
                {
                    name = typeRadios,
                    id = Guid.NewGuid(),
                    priceModifier = 0,
                    shipments = null,
                },

            };

            var quickest = graphingService1.getQuickestPath(shipment, toDestination, fromDestination);
            var cheapest = graphingService1.getCheapestPath(shipment, toDestination, fromDestination);




        }
    }
}
