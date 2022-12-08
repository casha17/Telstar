using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Telstar.Models;

namespace Telstar.Pages
{
    public class SummaryModel : PageModel
    {
        [BindProperty]
        public AlgorithmResult AlgorithmResult { get; set; }

        public void OnGet()
        {
            var data = TempData["path"] as string;
            AlgorithmResult = JsonSerializer.Deserialize<AlgorithmResult>(data);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
