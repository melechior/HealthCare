using System;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Infrastructures.Data.SqlServer.Personages.Repositories;

public class PersonageCommandRepository(HealthCareDbContext context) : IPersonagesCommandRepository
{
    public void Create(Personage personage)
    {
        context.Personages.Add(personage);
    }

    public void Create(List<Personage> personages)
    {
        context.Personages.AddRange(personages);
    }

    public void Edit(Personage personage)
    {
        context.Update(personage);
    }

    public void Delete(Personage personage)
    {
        context.Remove(personage);
    }
}