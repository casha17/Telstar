using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Telstar.Pages
{
    public class ConfirmationModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
