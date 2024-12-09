using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Enums;
using HealthCare.WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers;

[Authorize]
public class DetailsController : BaseController
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
    public IActionResult PersonageList(DataTableAjaxPostModel model)
    {
        var personId = HttpContext.Session.GetString("SelectedContractPersonId");
        if (string.IsNullOrWhiteSpace(personId))
        {
            return Json(new
            {
                draw = model.draw,
                recordsTotal = 0,
                recordsFiltered = 0,
                data = new PagedQueryResult<DamageFileDetailByStateQueryView>(),
            });
        }

        var page = (model.start / model.length) + 1;
        var query = new DamageFileDetailByStateQuery
        {
            PersonId = Convert.ToInt64(personId),
            SearchValue = model.search.value,
            PageIndex = page,
            PageSize = model.length,
            DamageFileStates = string.IsNullOrEmpty(model.columns[4].search.value)
                ? null
                : [(DamageFileState)Convert.ToInt32(model.columns[4].search.value)]
        };
        var t = model.order?[0];

        var damageFiles =
            QueryDispatcher.Dispatch<QueryResult<PagedQueryResult<DamageFileDetailByStateQueryView>>>(query);

        return Json(new
        {
            draw = model.draw,
            recordsTotal = damageFiles.QueryView.TotalCount,
            recordsFiltered = damageFiles.QueryView.TotalCount,
            data = damageFiles.QueryView.Data,
        });
    }
}