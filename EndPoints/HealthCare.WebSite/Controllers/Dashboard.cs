using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

public class Dashboard : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}