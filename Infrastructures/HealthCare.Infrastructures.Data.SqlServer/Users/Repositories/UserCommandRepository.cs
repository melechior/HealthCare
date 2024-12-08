using HealthCare.Core.Domains.Users.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructures.Data.SqlServer.Users.Repositories;

public class UserCommandRepository(HealthCareDbContext context) : IUserCommandRepository
{
    public void Create(User user)
    {
        context.Add(user);
    }

    public void Edit(User user)
    {
        context.Update(user);
    }

    public void Delete(User user)
    {
        context.Remove(user);
    }
}