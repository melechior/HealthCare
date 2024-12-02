using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}