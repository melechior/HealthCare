 
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.Contracts.Dtos;

public class ContractDto: Dto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public string StartDateShamsi { get; set; }
    public string EndDateShamsi { get; set; }
    public int CountOfPersons { get; set; }
    public bool IsActive { get; set; }

}
