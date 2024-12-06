using HealthCare.Framework.Queries;

namespace HealthCare.Core.Domains.ContractOfPersons.QueryViews;

public class ContractPeopleByNationalIdQueryView : QueryView
{
    public string NationalId { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public string ContractName { get; set; }
}