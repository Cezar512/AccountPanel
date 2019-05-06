using System.Reflection;
using Autofac;
using L2AccountPanel.Infrastructure.Commands;


namespace L2AccountPanel.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
         protected override void Load(ContainerBuilder builder)
         {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
         }
    }
}