using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TelstarLogistics.Models;
using TelstarLogistics.service;

namespace TelstarLogistics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DbContext dbContext { get; set; }
        private IshipmentService shipmentService { get; set; }

        public HomeController(ILogger<HomeController> logger, IshipmentService ishipmentService)
        {
            _logger = logger;
            shipmentService= ishipmentService;
            
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}