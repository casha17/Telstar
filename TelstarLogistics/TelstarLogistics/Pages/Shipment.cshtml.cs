using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TelstarLogistics.Pages
{
    public class ShipmentModel : PageModel
    {
        [BindProperty]
        public string emailAddress { get; set; }
        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost()
        {


            return new RedirectResult("Suppliers");
        }
    }
}
