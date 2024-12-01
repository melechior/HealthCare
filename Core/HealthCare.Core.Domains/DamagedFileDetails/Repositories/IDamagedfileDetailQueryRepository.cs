
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.DamagedFileDetails.Dto;
using HealthCare.Framework.Paging;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IDamagedFileDetailQueryRepository
{
    DamageFileDetail? GetById(long id);
    DamageFileDetail? GetFullDataById(long id);
    PagedQueryResult<DamageFileDetailDto> GetByFilter(List<DamageFileState>? states,int pageIndex, int pageSize);

    PagedQueryResult<DamageFileDetailDto> GetByFilter(List<DamageFileState>? states, string search, int pageIndex,
        int pageSize);

    PagedQueryResult<DamageFileDetailDto> GetByFilter(long? personId, List<DamageFileState>? states, string search,
        int pageIndex, int pageSize);
    
    //IList<Contract> GetByFilter();
    //List<ContractInfoDto> GetContractInfo(long? contractId);
    List<DamageFileDetailDto> GetDamageFileDetailByPersonId(long personId,long contractId);

    DamageFileControlDto? GetDetailFromDamageFileId(long id);
    long GetMaxReceiptNumber();

    bool IsPayment(long damageFileDetailId);
    
    List<DamageFileDetail> GetDamageDetailId(string nationalId,DateTime damageDate,decimal damageAmount);
    List<DamageFileDetail> GetDamageDetailId(string nationalId,DateTime damageDate,decimal damageAmount,string receiptNumber);
    List<DamageFileDetail> GetDamageDetailId(string nationalId,DateTime damageDate,decimal damageAmount,string receiptNumber,string damageItemName);
  
    decimal GetRestContractItemAmount(long contractItemId, long personageId);

    public List<DamageFileDetail> GetDamageDetailId(string nationalId, DamageFileState state);
}