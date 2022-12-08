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
        }

        public IActionResult OnPost(string weight, string height, string length, string width)
        {
            var data = TempData["path"] as string;
            var algorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(data);

            algorithmResult.shipment.widthInCm = Convert.ToDouble(width);
            algorithmResult.shipment.heightInCm = Convert.ToDouble(height); 
            algorithmResult.shipment.lengthInCm =  Convert.ToDouble(length);
            algorithmResult.shipment.weightInKg= Convert.ToDouble(weight);

            TempData["path"] = JsonSerializer.Serialize(algorithmResult);
            return RedirectToPage("ChooseRoute");


        }
    }
}
