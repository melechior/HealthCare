using HealthCare.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domains.Payments.Queries
{
    public class PaymentByPaymentIdQuery : IQuery
    {
        public List<long> PaymentIds { get; set; }
    }
}
