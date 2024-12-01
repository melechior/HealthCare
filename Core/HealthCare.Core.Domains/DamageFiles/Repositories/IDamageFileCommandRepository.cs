

using HealthCare.Core.Domains.DamageFiles.Entities;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IDamageFileCommandRepository
{
 void Create(DamageFile damageFile);
    void Edit(DamageFile damageFile);
    void Delete(DamageFile damageFile);
    void Delete(long id);
}