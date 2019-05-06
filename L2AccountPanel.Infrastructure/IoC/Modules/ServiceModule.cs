using System.Reflection;
using Autofac;
using L2AccountPanel.Infrastructure.Services;

namespace L2AccountPanel.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;


            builder.RegisterType<Encrypter>()
                   .As<IEncrypter>()
                    .SingleInstance();

            builder.RegisterType<JwtHandler>()
                   .As<IJwtHandler>()
                    .SingleInstance();
                    
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }       
    }
}