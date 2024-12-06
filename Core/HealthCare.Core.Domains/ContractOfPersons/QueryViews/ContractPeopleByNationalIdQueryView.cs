using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.ContractOfPersons.QueryViews;

public class ContractPeopleByNationalIdQueryView : QueryView
{
    public string NationalId { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public string ContractName { get; set; }
    public Relative Relative { get; set; }
    public bool? IsMan { get; set; }
}