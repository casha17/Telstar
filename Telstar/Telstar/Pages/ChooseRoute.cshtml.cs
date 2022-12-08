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
            var data = TempData["path"] as string;
            AlgorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(data);
            TempData["path"] = JsonSerializer.Serialize(AlgorithmResult);
            
        }

        public IActionResult OnPostFastest()
        {
            var data = TempData["path"] as string;
            var algorithmResult1 = JsonSerializer.Deserialize<AlgorithmResult>(data);
            algorithmResult1.cheapest = false;
            algorithmResult1.fastest = true;
            TempData["path"] = JsonSerializer.Serialize(algorithmResult1);
            return RedirectToPage("Summary");
        }

        public IActionResult OnPostCheapest()
        {
            var data = TempData["path"] as string;
            var algorithmResult1 = JsonSerializer.Deserialize<AlgorithmResult>(data);
            algorithmResult1.cheapest= true;
            algorithmResult1.fastest= false;
            TempData["path"] = JsonSerializer.Serialize(algorithmResult1);
            return RedirectToPage("Summary");
        }

        
    }
}
