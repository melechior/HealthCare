using HealthCare.Framework.Queries;


namespace HealthCare.Core.Domains.ContractOfPersons.Queries
{
    public class ContractPeopleByNationalIdQuery : IQuery
    {
        public string NationalId { get; set; }
    }
}