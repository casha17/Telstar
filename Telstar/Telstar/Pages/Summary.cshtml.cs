using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Telstar.Data;
using Telstar.Models;
using Telstar.service;

namespace Telstar.Pages
{
    public class SummaryModel : PageModel
    {
        private IshipmentService shipService { get; set; }

        public SummaryModel(IshipmentService context)
        {

            shipService = context;
        }


        [BindProperty]
        public AlgorithmResult AlgorithmResult { get; set; }

        public void OnGet()
        {
            var cookieValue = Request.Cookies["shipment"];
            AlgorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(cookieValue);
            
        }

        public IActionResult OnPost()
        {
            var cookieValue = Request.Cookies["shipment"];
            var result = JsonSerializer.Deserialize<AlgorithmResult>(cookieValue);
            if (result.shipment != null)
            {
                shipService.CreateShipment(result.shipment);
             
            }
            
            return RedirectToPage("/Confirmation");
        }

       
    }
}
