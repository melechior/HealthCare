using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Personages;
using HealthCare.Core.Domains.Personages.Dtos;
using HealthCare.Core.Domains.Users.Dtos;
using HealthCare.Framework.Paging;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IPersonagesQueryRepository
{
     Personage? GetById(long id);
    Personage? GetByNationalId(string nationalId);
    Personage? GetByInsuranceCoding(long systemNationalId);
    PagedQueryResult<PersonageDto> GetByFilter(int pageIndex, int pageSize);
    PagedQueryResult<PersonageDto> GetByFilter(string searchValue, int pageIndex, int pageSize);
    IList<PersonageDto> GetByFilter();
    IList<DamageFilePersonageInfoDto> GetAllPersonageInActiveContract();
    List<PersonageProfileDto> GetPersonProfile(long personId);
}