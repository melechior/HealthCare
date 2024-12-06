using HealthCare.Framework.Queries;
using Microsoft.Extensions.Primitives;


namespace HealthCare.Core.Domains.ContractOfPersons.Queries
{
    public class ContractPeopleByNationalIdQuery:IQuery
    {
        public string NationalId{ get; set; }
    }
}
