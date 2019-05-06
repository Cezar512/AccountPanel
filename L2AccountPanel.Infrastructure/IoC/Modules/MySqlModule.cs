using System.Reflection;
using Autofac;
using L2AccountPanel.Infrastructure.Repositories;

namespace L2AccountPanel.Infrastructure.IoC.Modules
{
    public class MySqlModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(MySqlModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IMySqlRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}