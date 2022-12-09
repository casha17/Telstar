using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Telstar.Models;

namespace Telstar.Pages
{
    public class DimensionPageModel : PageModel
    {
        public void OnGet()
        {
            var cookieValue = Request.Cookies["shipment"];
            var algorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(cookieValue);
            
        }

        public IActionResult OnPost(string weight, string height, string length, string width)
        {

            var cookieValue = Request.Cookies["shipment"];
            var algorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(cookieValue);
            

            algorithmResult.shipment.widthInCm = Convert.ToDouble(width);
            algorithmResult.shipment.heightInCm = Convert.ToDouble(height); 
            algorithmResult.shipment.lengthInCm =  Convert.ToDouble(length);
            algorithmResult.shipment.weightInKg= Convert.ToDouble(weight);

            Response.Cookies.Append("shipment", JsonSerializer.Serialize(algorithmResult));
            return RedirectToPage("ChooseRoute");


        }
    }
}
