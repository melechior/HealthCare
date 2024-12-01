using System;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructures.Data.SqlServer.DamageFiles.Repositories;

public class DamageFileCommandRepository(HealthCareDbContext context) : IDamageFileCommandRepository
{
    public void Create(DamageFile damageFile)
    {
        context.Add(damageFile);
    }

    public void Edit(DamageFile damageFile)
    {
        context.Update(damageFile);
    }

    public void Delete(DamageFile damageFile)
    {
        context.Remove(damageFile);
    }

    public void Delete(long id)
    {
        var damageFile = context.DamageFiles
            .Include(x => x.DamageFileDetails)
     
            .Include(x => x.DamageFileDetails)
            
            .Single(x => x.Id == id);
        foreach (var detail in damageFile.DamageFileDetails)
        {
          

         

            context.DamageFileDetails.Remove(detail);
        }

        context.DamageFiles.Remove(damageFile);
    }
}