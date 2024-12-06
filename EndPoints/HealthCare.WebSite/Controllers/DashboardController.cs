using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

[Authorize]
public class DashboardController : BaseController
{
    // GET
    [Authorize]
    [HttpGet]
    public IActionResult Index()
    {
        HttpContext.Session.Get("SelectedContractPersonId");
        return View();
    }
}