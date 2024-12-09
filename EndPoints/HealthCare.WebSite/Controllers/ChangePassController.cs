using HealthCare.Core.Domains.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

[Authorize]
public class ChangePassController : BaseController
{
    // GET
    [Authorize]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Change(ChangePasswordCommand command)
    {
        command.UserId = UserId;
        var commandResult = CommandDispatcher.Dispatch(command);

        return Json(commandResult);
    }
}