using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Infrastructures.Data.SqlServer;

public class UnitOfWork(HealthCareDbContext context) : IUnitOfWork
{
    public IUserCommandRepository UserCommandRepository { get; }
    public IUserQueryRepository UserQueryRepository { get; }

    public int Commit()
    {
        return context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            context.Dispose();
        }
    }
}