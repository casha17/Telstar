using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Telstar.service;
using Telstar.service;

namespace Telstar.Pages
{
    public class ReportModel : PageModel
    {

        private readonly IReportService _Ireportservice;

        public double totalProfit;
        public double totalBookings;

        public ReportModel(IReportService iReportService ) {
            _Ireportservice = iReportService;
            totalProfit = _Ireportservice.GetTotalPrice();
            totalBookings = _Ireportservice.GetTotalBookings();
        }

        public void OnGet()
        {
        }
    }
}
