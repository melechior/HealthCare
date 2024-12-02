using HealthCare.Core.Domains.DamagedFileDetails.Repositories;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Infrastructures.Data.SqlServer;

public class UnitOfWork(HealthCareDbContext context) : IUnitOfWork
{
    public IUserCommandRepository UserCommandRepository { get; }
    public IUserQueryRepository UserQueryRepository { get; }
    public IContractCommandRepository ContractCommandRepository { get; }
    public IContractofPersonCommandRepository ContractOfPersonCommandRepository{ get; }

    public IContractOfPersonQueryRepository ContractOfPersonQueryRepository { get; }

    public IContractQueryRepository ContractQueryRepository { get; }

    public IDamagedFileDetailCommandRepository DamagedFileDetailCommandRepository { get; }
    public IDamagedFileDetailQueryRepository DamagedFileDetailsQueryRepository { get; }

    public IDamagedFileDetailQueryRepository DamagedFileDetaileQueryRepository{ get; }

    public IDamageFileCommandRepository DamageFileCommandRepository { get; }

    public IDamageFileQueryRepository DamageFileQueryRepository { get; }

    public IPersonagesCommandRepository PersonagesCommandRepository { get; }

    public IPersonagesQueryRepository PersonagesQueryRepository { get; }

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