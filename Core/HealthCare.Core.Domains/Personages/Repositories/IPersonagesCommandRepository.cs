using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Users.Entities;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IPersonagesCommandRepository
{
    void Create(Personage personage);
    void Create(List<Personage> personages);
    void Edit(Personage personage);
    void Delete(Personage personage);
}