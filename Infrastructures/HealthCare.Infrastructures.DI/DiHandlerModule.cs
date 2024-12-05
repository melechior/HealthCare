using Autofac;
using HealthCare.Framework.Commands;
using HealthCare.Framework.Queries;

namespace HealthCare.Infrastructures.DI;

public class DiHandlerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region UnitOfWorkDi

        //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
        builder.RegisterType<CommandDispatcher>().InstancePerDependency();
        builder.RegisterType<QueryDispatcher>().InstancePerDependency();

        #endregion
    }
}