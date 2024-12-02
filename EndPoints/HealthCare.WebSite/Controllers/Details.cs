using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

public class Details : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}