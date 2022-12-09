using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Telstar.Models;

namespace Telstar.Pages
{
    public class ChooseRouteModel : PageModel
    {
        [BindProperty]
        public AlgorithmResult AlgorithmResult { get; set; }
        public void OnGet()
        {
            var cookieValue = Request.Cookies["shipment"];
            AlgorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(cookieValue);

            
            
        }

        public IActionResult OnPostFastest()
        {
            var cookieValue = Request.Cookies["shipment"];
            var algorithmresult = JsonSerializer.Deserialize<AlgorithmResult>(cookieValue);


            algorithmresult.cheapest = false;
            algorithmresult.fastest = true;

            Response.Cookies.Append("shipment", JsonSerializer.Serialize(algorithmresult));
            return RedirectToPage("Summary");
        }

        public IActionResult OnPostCheapest()
        {
            var cookieValue = Request.Cookies["shipment"];
            var algorithmresult = JsonSerializer.Deserialize<AlgorithmResult>(cookieValue);


            algorithmresult.cheapest = true;
            algorithmresult.fastest = false;

            Response.Cookies.Append("shipment", JsonSerializer.Serialize(algorithmresult));
            return RedirectToPage("Summary");
        }

        
    }
}
