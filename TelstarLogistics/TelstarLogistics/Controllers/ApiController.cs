using Microsoft.AspNetCore.Mvc;

namespace TelstarLogistics.Controllers;

public class ApiController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}