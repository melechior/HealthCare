using HealthCare.Core.Domains.DamageFiles.Dtos;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Framework.Paging;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IDamageFileQueryRepository
{
  
  DamageFile? GetById(long id);

    PagedQueryResult<DamageFileListDto> GetByFilter(string? searchValue, long? contractId, long? humanReceiptNumber,
        long? systemReceiptNumber, DateTime? fromDate, DateTime? toDate, string? mainPersonNationalId,
        string? mainPersonFullname, List<DamageFileState>? states, int pageIndex, int pageSize);

    IList<DamageFile> GetByFilter();
    List<DamageFileDto> GetDamageFile(long? contractId);
    List<DamageReportDto> GetDamageReport(long? id);
    List<DamageMoalemReportDto> GetDamageMoalemReport(long id);
 
}
 