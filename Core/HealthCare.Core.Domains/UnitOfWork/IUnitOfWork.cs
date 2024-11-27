using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Core.Domains.UnitOfWork;

public interface IUnitOfWork
{
    IUserCommandRepository UserCommandRepository { get; }
    IUserQueryRepository UserQueryRepository { get; }
    int Commit();
}