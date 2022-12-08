using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Telstar.Pages
{
    public class ShipmentModel : PageModel
    {
        [BindProperty]
        public string fromDestination { get; set; }
        public void OnGet()
        {
        }

        public void OnPost(string fromDestination)
        {

        }
    }
}
