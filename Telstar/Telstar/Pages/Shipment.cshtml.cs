using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Telstar.Models;
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

        public ShipmentModel(IshipmentService ishipmentService)
        {
            var listOfDestinations = ishipmentService.GetDestination();
            destinations = new List<String>();
            listOfDestinations.ForEach(elem => destinations.Add(elem.City));
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
                    name= typeRadios,
                    id= Guid.NewGuid(),
                    priceModifier  = 0,
                    shipments = null,
                },
                
            }


        }
    }
}
