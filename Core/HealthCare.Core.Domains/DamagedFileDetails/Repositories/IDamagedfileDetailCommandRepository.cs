using HealthCare.Core.Domains.DamagedFileDetails;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IDamagedFileDetailCommandRepository
{
    void Create(DamageFileDetail damageFileDetail);
    void Edit(DamageFileDetail damageFileDetail);
    void Delete(DamageFileDetail damageFileDetail);
    
}