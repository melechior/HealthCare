using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
 
//using HealthCare.Core.Domains.OutdoorReceipts.QueryViews;
using HealthCare.Core.Domains.Payments.QueryViews;
using HealthCare.Infrastructures.Shared.Enums;
using HealthCare.Infrastructures.Shared.Helpers;

namespace FastReport;
 
    public class ReportGenerator
    {

        public MemoryStream? MakeReport(List<DamageFileDetailByPendingStateQueryView> query,
         List<PaymentByPaymentIdQueryView> payments)
        {
            Utils.Config.WebMode = true;
            Utils.Config.RightToLeft = true;
            var report = new Report();
            var path = $@"{Environment.CurrentDirectory}\Reports\DamageFileDetailState.frx";
            report.Load(path);
            var personName = query.First().Fullname;
            var contractName = query.First().ContractNumber;
            var national = query.First().NationalId;
            report.SetParameterValue("NationalId", national);
            report.SetParameterValue("PersonName", personName);
            report.SetParameterValue("ContractName", contractName);
            report.SetParameterValue("PersianReportDate", DateTime.Now.Date.GeorgianDateToPersianDate());

            query.ForEach(item =>
            {
                if (item.DamageFileState != DamageFileState.Defective01 &&
                    item.DamageFileState != DamageFileState.Defective02 && item.DamageFileState != DamageFileState.Rejected)
                {
                    item.DamageFileStateName = "در حال بررسی";
                }
            });

            report.RegisterData(query.Where(x => !x.PaymentId.HasValue).ToList(), "DamageFileDetailRef");
            report.RegisterData(query.Where(x => x.PaymentId.HasValue).ToList(), "PaymentDamageFileDetailRef");
            report.RegisterData(payments, "PaymentRef");

            if (!report.Report.Prepare()) return null;

            var pdfExport = new Export.PdfSimple.PDFSimpleExport();
            pdfExport.ShowProgress = false;
            pdfExport.Subject = "Subject";
            pdfExport.Title = $"Report-{national}";
            //pdfExport.Title = $"شماره رسید-{query.ReceiptNumber}";
            var ms = new MemoryStream();
            report.Export(pdfExport, ms);
            report.Dispose();
            pdfExport.Dispose();
            ms.Position = 0;
            return ms;
        }
    }
 