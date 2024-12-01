using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Core.Domains.UnitOfWork;

public interface IUnitOfWork
{
    IUserCommandRepository UserCommandRepository { get; }
    IUserQueryRepository UserQueryRepository { get; }
    IContractofPersonCommandRepository ContractofPersonCommandRepository{get;}
    IContractOfPersonQueryRepository ContractOfPersonQueryRepository{get;}
    IContractCommandRepository ContractCommandRepository{get;}
    IContractQueryRepository ContractQueryRepository{get;}
    IDamagedFileDetailCommandRepository DamagedfileDetailCommandRepository{get;}
    IDamagedFileDetailQueryRepository DamagedfileDetailrQueryRepository{get;}
    IDamageFileCommandRepository DamageFileCommandRepository{get;}
    IDamageFileQueryRepository DamageFileQueryRepository{get;}
    IPersonagesCommandRepository PersonagesCommandRepository{get;}
    IPersonagesQueryRepository PersonagesQueryRepository{get;}
    int Commit();
}