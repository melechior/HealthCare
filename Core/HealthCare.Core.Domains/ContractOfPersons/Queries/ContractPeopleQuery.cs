using HealthCare.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Domains.ContractOfPersons.Queries
{
    public class ContractPeopleQuery : IQuery
    {

        public long MainPersonId { get; set; }
        public long ContractId { get; set; }
    }
 
}
