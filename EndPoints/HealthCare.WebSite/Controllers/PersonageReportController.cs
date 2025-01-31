using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Core.Domains.Payments.Queries;
using HealthCare.Core.Domains.Payments.QueryViews;
using HealthCare.Core.Domains.Personages.Queries;
 
using HealthCare.Core.Domains.Personages.QueryViews;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.WebSite.Models;
using  FastReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebSite.Controllers
{
    public class PersonageReportController : BaseController
    {
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PersonageDamageReport(long id)
        {
            return View(id);
        }

        [HttpPost]
        public IActionResult PersonageList(DataTableAjaxPostModel model)
        {
            var page = (model.start / model.length) + 1;
            var query = new AllPersonQuery
            {
                SearchValue = model.search.value,
                PageIndex = page,
                PageSize = model.length,
            };

            var persons = QueryDispatcher.Dispatch<QueryResult<PagedQueryResult<AllPersonQueryView>>>(query);

            return Json(new
            {
                draw = model.draw,
                recordsTotal = persons.QueryView.TotalCount,
                recordsFiltered = persons.QueryView.TotalCount,
                data = persons.QueryView.Data,
            });
        }

        [HttpPost]
        public IActionResult PrintDamageFileDetailByPersonageReport(long id)
        {
            var query = new DamageFileDetailByPendingStateQuery
            {
                PersonId = id,
            };

            var damageFileDetailsByPersons =
                QueryDispatcher.Dispatch<QueryResult<List<DamageFileDetailByPendingStateQueryView>>>(query);

            var paymentIds = damageFileDetailsByPersons.QueryView
                .Where(x => x.PaymentId.HasValue)
                .DistinctBy(x => x.PaymentId)
                .Select(x => x.PaymentId!.Value).ToList();

            var payments = QueryDispatcher.Dispatch<QueryResult<List<PaymentByPaymentIdQueryView>>>(
                new PaymentByPaymentIdQuery
                {
                    PaymentIds = paymentIds
                });

            var memory = new ReportGenerator().MakeReport(damageFileDetailsByPersons.QueryView.ToList(), payments.QueryView.ToList());

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
            return Json("{}");
        }
    }
}