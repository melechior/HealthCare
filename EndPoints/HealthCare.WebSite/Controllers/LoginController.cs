using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Core.Domains.ContractOfPersons.QueryViews;
using HealthCare.Core.Domains.ContractOfPersons.Queries;
using Newtonsoft.Json;

namespace HealthCare.WebSite.Controllers;

public class LoginController : BaseController
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public JsonResult EnterLogin(LoginQuery query)
    {
        var queryResult = QueryDispatcher.Dispatch<QueryResult<LoginQueryView>>(query);


        if (queryResult.Failed) return Json(queryResult);
        var claims = new List<Claim>
        {
            new Claim("UserId", queryResult.QueryView.Id.ToString()),
            new Claim("IsAdmin", queryResult.QueryView.IsAdmin.ToString()),
            new Claim("Username", queryResult.QueryView.Username),
            //new Claim("Image", queryResult.QueryView.ImageBase64),
            new Claim("JobPosition", queryResult.QueryView.JobPosition),
            new Claim("Fullname", $"{queryResult.QueryView.Firstname} {queryResult.QueryView.LastName}"),
            //new Claim("Email", queryResult.QueryView.Email != null ? queryResult.QueryView.Email : ""),
            new Claim("LatestLoginDate", DateTime.Now.GeorgianDateToPersianDate()),
            new Claim("LatestLoginTime", DateTime.Now.ToShortTimeString()),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            IsPersistent = query.MemberMe,
            ExpiresUtc = DateTime.UtcNow.AddMinutes(120),
        };

        var contractOfPeople =
            QueryDispatcher.Dispatch<QueryResult<List<ContractPeopleByNationalIdQueryView>>>(
                new ContractPeopleByNationalIdQuery
                {
                    NationalId = queryResult.QueryView.NationalId
                });

        HttpContext.Session.SetString("ContractOfPeople", JsonConvert.SerializeObject(contractOfPeople.QueryView));

        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return Json(queryResult);
    }

    [AllowAnonymous]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync().Wait();
        return Redirect($"/Login/Index");
    }

    [Authorize]
    [HttpPost]
    public IActionResult ChangeSelectedPersonId(long id)
    {
        HttpContext.Session.SetString("SelectedContractPersonId", id.ToString());
        return Ok();
    }
}