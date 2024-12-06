using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        HttpContext.Session.Get("SelectedContractPersonId");
        return View();
    }
}