using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domains.Personages.Queries
{
    public class AllPersonQuery : PagedQuery, IQuery
    {
        public string SearchValue { get; set; }
    }
}