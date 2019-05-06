using Autofac;
using L2AccountPanel.Infrastructure.Mappers;
using L2AccountPanel.Infrastructure.IoC.Modules;
using Microsoft.Extensions.Configuration;
namespace L2AccountPanel.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<MySqlModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}