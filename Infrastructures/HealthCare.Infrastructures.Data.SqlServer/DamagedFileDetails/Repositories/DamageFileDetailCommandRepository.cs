
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Repositories;

public class DamageFileDetailCommandRepository(HealthCareDbContext context) : IDamagedFileDetailCommandRepository
{
    public void Create(DamageFileDetail damageFileDetail)
    {
        throw new NotImplementedException();
    }

    public void Edit(DamageFileDetail damageFileDetail)
    {
        context.Update(damageFileDetail);
    }

    public void Delete(DamageFileDetail damageFileDetail)
    {
         
        context.DamageFileDetails.Remove(damageFileDetail);
    }

     
}

 