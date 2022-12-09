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
            var data = TempData["path"] as string;
            AlgorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(data);
            TempData["path"] = JsonSerializer.Serialize(AlgorithmResult);
        }

        public IActionResult OnPost()
        {
            var data = TempData["path"] as string;
            var result = JsonSerializer.Deserialize<AlgorithmResult>(data);
            if(result.shipment != null)
            {
                shipService.CreateShipment(result.shipment);
             
            }
            
            return RedirectToPage("/Confirmation");
        }

       
    }
}
