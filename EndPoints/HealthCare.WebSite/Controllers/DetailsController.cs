using FastReport;
using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Core.Domains.Payments.Queries;
using HealthCare.Core.Domains.Payments.QueryViews;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
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
                data = new List<DamageFileDetailByStateQueryView>(),
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

    [Authorize]
    [HttpPost]
    public IActionResult Print()
    {
        var contractPersonId = HttpContext.Session.GetString("SelectedContractPersonId");
        if (contractPersonId == null)
        {
            return Redirect("/");
        }

        var query = new DamageFileDetailByPendingStateQuery
        {
            PersonId = Convert.ToInt64(contractPersonId),
        };

        var damageFileDetailsByPersons =
            QueryDispatcher.Dispatch<QueryResult<List<DamageFileDetailByPendingStateQueryView>>>(query);

        if (damageFileDetailsByPersons.QueryView.Count == 0)
        {
            return Json(new QueryResult<List<DamageFileDetailByPendingStateQueryView>>
            {
                Failed = true,
                ResultMessages = new List<ResultMessage>
                {
                    new ResultMessage
                    {
                        MessageType = MessageType.Danger,
                        Message = "ردیفی برای چاپ یافت نشد"
                    }
                }
            });
        }

            var paymentIds = damageFileDetailsByPersons.QueryView
                .Where(x => x.PaymentId.HasValue)
                .DistinctBy(x => x.PaymentId)
                .Select(x => x.PaymentId!.Value).ToList();

        var payments = QueryDispatcher.Dispatch<QueryResult<List<PaymentByPaymentIdQueryView>>>(
            new PaymentByPaymentIdQuery
            {
                PaymentIds = paymentIds
            });

        var memory = new ReportGenerator().MakeReport(damageFileDetailsByPersons.QueryView.ToList(),
            payments.QueryView.ToList());

        if (memory == null)
        {
            return NotFound();
        }

        return Json(new
        {
            //FileName = $"Receipt{queryResult.QueryView.ReceiptNumber}.pdf",
            FileName = $"PrintDamage-{damageFileDetailsByPersons.QueryView.First().NationalId}.pdf",
            FileSource = Convert.ToBase64String(memory.ToArray())
        });
    }
}