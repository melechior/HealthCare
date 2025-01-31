using HealthCare.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domains.Personages.QueryViews
{
    public class AllPersonQueryView : QueryView
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public bool IsActive { get; set; }
        public string Contracts { get; set; }
    }
}
