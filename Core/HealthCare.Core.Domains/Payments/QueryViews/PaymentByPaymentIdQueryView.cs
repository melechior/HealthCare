using HealthCare.Framework.Queries;
 

namespace HealthCare.Core.Domains.Payments.QueryViews
{
    public class PaymentByPaymentIdQueryView: QueryView
    {
        public string ReceiptNumber { get; set; }
        public string PersianPaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string? ShebaNumber { get; set; }
    }
}
