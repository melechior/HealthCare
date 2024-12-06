using HealthCare.Framework.Queries;

namespace HealthCare.Core.Domains.ContractOfPersons.QueryViews
{
    public class ContractPeopleQueryView:QueryView
    {
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
