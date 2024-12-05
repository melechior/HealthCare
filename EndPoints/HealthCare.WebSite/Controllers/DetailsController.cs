using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

public class DetailsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}