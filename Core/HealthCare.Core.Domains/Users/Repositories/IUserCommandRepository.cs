using HealthCare.Core.Domains.Users.Entities;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IUserCommandRepository
{
    void Create(User user);
    void Edit(User user);
    void Delete(User user);
}