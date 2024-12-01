using HealthCare.Core.Domains.DamagedFileDetails.Repositories;
using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Core.Domains.UnitOfWork;

public interface IUnitOfWork
{
    IUserCommandRepository UserCommandRepository { get; }
    IUserQueryRepository UserQueryRepository { get; }
    IContractofPersonCommandRepository ContractOfPersonCommandRepository{get;}
    IContractOfPersonQueryRepository ContractOfPersonQueryRepository{get;}
    IContractCommandRepository ContractCommandRepository{get;}
    IContractQueryRepository ContractQueryRepository{get;}
    IDamagedFileDetailCommandRepository DamagedFileDetailCommandRepository{get;}
    IDamagedFileDetailQueryRepository DamagedFileDetailsQueryRepository{get;}
    IDamageFileCommandRepository DamageFileCommandRepository{get;}
    IDamageFileQueryRepository DamageFileQueryRepository{get;}
    IPersonagesCommandRepository PersonagesCommandRepository{get;}
    IPersonagesQueryRepository PersonagesQueryRepository{get;}
    
    int Commit();
}