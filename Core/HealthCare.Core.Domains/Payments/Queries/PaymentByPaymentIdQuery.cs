using HealthCare.Framework.Queries;

namespace HealthCare.Core.Domains.Payments.Queries
{
    public class PaymentByPaymentIdQuery : IQuery
    {
        public List<long> PaymentIds { get; set; }
    }
}
