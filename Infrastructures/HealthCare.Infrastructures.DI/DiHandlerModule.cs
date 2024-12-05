using Autofac;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Commands;
using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Data.SqlServer;
using HealthCare.Core.ApplicationServices.Users.QueryHandlers;
using HealthCare.Core.Domains.Users.Repositories;
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

        #endregion


        #region Query Handler Di

        builder.RegisterType<LoginQueryHandler>().As<IQueryHandler<LoginQuery, QueryResult<LoginQueryView>>>()
    .InstancePerDependency();


        #endregion

    }
}