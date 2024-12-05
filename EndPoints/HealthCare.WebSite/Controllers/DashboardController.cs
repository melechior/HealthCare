using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}