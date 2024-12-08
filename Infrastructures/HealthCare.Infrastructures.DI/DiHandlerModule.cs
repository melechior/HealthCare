using Autofac;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Commands;
using HealthCare.Framework.Queries;
using HealthCare.Core.ApplicationServices.Users.QueryHandlers;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Core.ApplicationServices.ContractOfPersons.QueryHandlers;
using HealthCare.Core.ApplicationServices.DamagedFileDetails.QueryHandlers;
using HealthCare.Core.ApplicationServices.Users.CommandHandlers;
using HealthCare.Core.Domains.ContractOfPersons.Queries;
using HealthCare.Core.Domains.ContractOfPersons.QueryViews;
using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Core.Domains.DamagedFileDetails.Repositories;
using HealthCare.Core.Domains.Users.Commands;
using HealthCare.Framework.Paging;
using HealthCare.Infrastructures.Data.SqlServer;
using HealthCare.Infrastructures.Data.SqlServer.ContractOfPersons.Repositories;
using HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Repositories;
using HealthCare.Infrastructures.Data.SqlServer.Users.Repositories;

namespace HealthCare.Infrastructures.DI;

public class DiHandlerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region UnitOfWorkDi

        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
        builder.RegisterType<CommandDispatcher>().InstancePerDependency();
        builder.RegisterType<QueryDispatcher>().InstancePerDependency();

        #endregion

        #region Repository Di

        builder.RegisterType<UserCommandRepository>().As<IUserCommandRepository>().InstancePerDependency();
        builder.RegisterType<UserQueryRepository>().As<IUserQueryRepository>().InstancePerDependency();

        builder.RegisterType<ContractOfPersonCommandRepository>().As<IContractofPersonCommandRepository>()
            .InstancePerDependency();

        builder.RegisterType<ContractOfPersonQueryRepository>().As<IContractOfPersonQueryRepository>()
            .InstancePerDependency();

        builder.RegisterType<DamageFileDetailQueryRepository>().As<IDamagedFileDetailQueryRepository>()
            .InstancePerDependency();

        #endregion

        #region Query Handler Di

        #region User

        builder.RegisterType<LoginQueryHandler>().As<IQueryHandler<LoginQuery, QueryResult<LoginQueryView>>>()
            .InstancePerDependency();

        builder.RegisterType<ChangePasswordCommandHandler>().As<CommandHandler<ChangePasswordCommand>>()
            .InstancePerDependency();

        #endregion

        #region ContractOfPersons

        builder.RegisterType<ContractOfPersonsQueryHandlers>()
            .As<IQueryHandler<ContractPeopleQuery, QueryResult<List<ContractPeopleQueryView>>>>()
            .InstancePerDependency();

        builder.RegisterType<ContractPeopleByNationalIdQueryHandler>()
            .As<IQueryHandler<ContractPeopleByNationalIdQuery,
                QueryResult<List<ContractPeopleByNationalIdQueryView>>>>()
            .InstancePerDependency();

        #endregion

        #region damageFileDetails

        builder.RegisterType<DamageFileDetailByStateQueryHandler>()
            .As<IQueryHandler<DamageFileDetailByStateQuery,
                QueryResult<PagedQueryResult<DamageFileDetailByStateQueryView>>>>()
            .InstancePerDependency();

        #endregion

        #endregion
    }
}